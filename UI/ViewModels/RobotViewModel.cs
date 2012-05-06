namespace UI.ViewModels
{
    public class RobotViewModel : ViewModelBase
    {
        #region RobotIs enum

        public enum RobotIs
        {
            Loading,
            Ready,
            Stopped,
            Moving
        }

        #endregion

        #region Properties and Indexers

        public string Say { get; private set; }
        public string Color { get; private set; }
        public string Margin { get; private set; }

        #endregion

        #region Constructors and Destructor

        public RobotViewModel() {
            ChangeState(RobotIs.Loading);
        }

        #endregion

        #region Public Methods

        public void ChangeState(RobotIs robotIs) {
            Margin = "60,50,0,0";

            switch (robotIs) {
                case RobotIs.Loading:
                    Say = "Loading";
                    Color = "#FFFF9600";
                    Margin = "50,50,0,0";
                    break;
                case RobotIs.Ready:
                    Say = "Ready!";
                    Color = "#FF009600";
                    break;
                case RobotIs.Stopped:
                    Say = "Stopped";
                    Color = "#FFFF0000";
                    break;
                case RobotIs.Moving:
                    Say = "Moving";
                    Color = "#FF0000FF";
                    break;
            }

            OnPropertyChanged("Say");
            OnPropertyChanged("Color");
            OnPropertyChanged("Margin");
        }

        #endregion
    }
}