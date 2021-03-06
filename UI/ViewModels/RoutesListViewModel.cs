using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Model;
using UI.Commands;
using Utils;
using lejOS;

namespace UI.ViewModels
{
    public class RoutesListViewModel : ViewModelBase
    {
        #region Properties and Indexers

        public bool AutomaticMode { get; private set; }
        public ObservableCollection<RouteViewModel> Routes { get; private set; }

        public ICommand PassRouteCommand {
            get { return passRouteCommand ?? (passRouteCommand = new DelegateCommand(PassRoute, CanPassRoute)); }
        }

        public ICommand ChangeModeCommand {
            get { return changeModeCommand ?? (changeModeCommand = new DelegateCommand(ChangeMode)); }
        }

        public bool IsAutomaticModeEnabled {
            get { return robotFace.State == RobotViewModel.RobotIs.Ready; }
        }

        #endregion

        #region Fields

        private readonly SocketListener newRoutesListener;
        private readonly Robot robot = new Robot();
        private readonly RobotViewModel robotFace;
        private DelegateCommand changeModeCommand;
        private DelegateCommand passRouteCommand;

        #endregion

        #region Constructors and Destructor

        public RoutesListViewModel(RobotViewModel robotFace) {
            this.robotFace = robotFace;
            AutomaticMode = true;
            Routes = new ThreadSafeObservableCollection<RouteViewModel>();
            newRoutesListener = new SocketListener(2000) {Working = true};
            Refresh();
            SubscribeToEvents();
        }

        #endregion

        #region Protected And Private Methods

        private void SubscribeToEvents() {
            robot.Ready += () => {
                robotFace.ChangeState(RobotViewModel.RobotIs.Ready);
                OnPropertyChanged("IsAutomaticModeEnabled");
            };

            robot.Moving += () => {
                robotFace.ChangeState(RobotViewModel.RobotIs.Moving);
                OnPropertyChanged("IsAutomaticModeEnabled");
            };

            robot.Error += () => {
                robotFace.ChangeState(RobotViewModel.RobotIs.Stopped);
                OnPropertyChanged("IsAutomaticModeEnabled");
            };

            newRoutesListener.Received += id => {
                Refresh();
                // TODO: implement as queue
                if (robotFace.State == RobotViewModel.RobotIs.Ready) {
                    Db.GetRouteById(Guid.Parse(id), route => robot.PassRoute(route));
                }
            };
        }

        private void Refresh() {
            Db.SelectAllRoutes(routes => {
                foreach (var r in (from rd in routes select rd).OrderBy(k => k.Steps.Count)) {
                    Routes.Add(new RouteViewModel(r));
                }
                OnPropertyChanged("Routes");
                robotFace.ChangeState(RobotViewModel.RobotIs.Ready);
                OnPropertyChanged("IsAutomaticModeEnabled");
            });
        }

        private void PassRoute() {
            var routeViewModel = (from r in Routes where r.IsSelected select r).Single();
            robot.PassRoute(routeViewModel.Route);
        }

        private void ChangeMode() {
            AutomaticMode = !AutomaticMode;
            OnPropertyChanged("AutomaticMode");
        }

        private bool CanPassRoute() {
            return !AutomaticMode && IsAnyRouteSelected() && robotFace.State == RobotViewModel.RobotIs.Ready;
        }

        private bool IsAnyRouteSelected() {
            return (from r in Routes where r.IsSelected select r).Any();
        }

        #endregion
    }
}