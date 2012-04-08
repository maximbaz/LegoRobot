using System.Windows;

namespace LegoRobot.UI
{
    public partial class MainWindow
    {
        #region Fields

        private readonly Robot robot = new Robot();

        #endregion

        #region Constructors and Destructor

        public MainWindow() {
            InitializeComponent();
        }

        #endregion

        #region Protected And Private Methods

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            Db.PassFirstRoute(route => robot.PassRoute(route));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            Db.FillDbWithFakeRoute();
        }

        #endregion
    }
}