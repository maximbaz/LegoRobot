namespace UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties and Indexers

        public static MainViewModel Current { get; private set; }
        public RobotViewModel RobotFace { get; private set; }
        public LogsListViewModel LogsListViewModel { get; private set; }
        public RoutesListViewModel RoutesListViewModel { get; private set; }

        #endregion

        #region Constructors and Destructor

        static MainViewModel() {
            Current = new MainViewModel();
        }

        public MainViewModel() {
            RobotFace = new RobotViewModel();
            LogsListViewModel = new LogsListViewModel();
            RoutesListViewModel = new RoutesListViewModel(RobotFace);
        }

        #endregion
    }
}