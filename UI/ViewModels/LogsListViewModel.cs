using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Model.Routing;

namespace UI.ViewModels
{
    public class LogsListViewModel : ViewModelBase
    {
        #region Properties and Indexers

        public List<LogViewModel> Logs { get; private set; }

        public bool AndLogic {
            get { return andLogic; }
            set {
                andLogic = value;
                OnFilterChange();
            }
        }

        public bool Succeed {
            get { return succeed; }
            set {
                succeed = value;
                OnFilterChange();
            }
        }

        public DateTime Finished {
            get { return finished; }
            set {
                finished = value;
                OnFilterChange();
            }
        }

        public RouteViewModel SelectedRouteViewModel {
            get { return selectedRouteViewModel; }
            set {
                selectedRouteViewModel = value;
                OnFilterChange();
            }
        }

        #endregion

        #region Fields

        private bool andLogic;
        private DateTime finished;
        private bool succeed;
        private RouteViewModel selectedRouteViewModel;

        #endregion

        #region Constructors and Destructor

        public LogsListViewModel() {
            Finished = DateTime.Now;
            Succeed = true;
        }

        #endregion

        #region Protected And Private Methods

        private void OnFilterChange() {
            Db.GetAllLogs(logs => {
                Logs = (from l in logs
                        where AndLogic
                                  ? (l.Succeed == Succeed && l.Finish.Date == Finished.Date && IsRouteSelected(l.Route))
                                  : (l.Succeed == Succeed || l.Finish.Date == Finished.Date || IsRouteSelected(l.Route))
                        orderby l.Route.Steps.Count 
                        select new LogViewModel(l)).ToList();

                OnPropertyChanged("Logs");
            });
        }

        private bool IsRouteSelected(Route route) {
            return SelectedRouteViewModel == null || SelectedRouteViewModel.Route == route;
        }

        #endregion
    }

    public class LogViewModel
    {
        public LogViewModel(Log log) {
            Finished = log.Finish.ToShortDateString();
            Route = "Route of " + log.Route.Steps.Count + " steps";
            Succeed = log.Succeed;
        }

        public string Route { get; private set; }
        public string Finished { get; private set; }
        public bool Succeed { get; private set; }
    }
}