using System.Linq;
using System.Windows;

namespace LegoRobot.UI
{
    public partial class MainWindow
    {
        private readonly Robot robot = new Robot();

        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            var route = (from r in Db.Context.Routes select r).First();
            robot.PassRoute(route);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            Db.FillDbWithFakeRoute();
        }
    }
}