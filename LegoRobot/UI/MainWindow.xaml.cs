using LegoRobot.Routing;

namespace LegoRobot.UI
{
    public partial class MainWindow
    {
        private RouteContext context = new RouteContext();

        public MainWindow() {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.Windows.RoutedEventArgs e) {
            context.Points.Add(new Point());
            context.SaveChanges();
            pointDataGrid.Items.Refresh();
        }
    }
}