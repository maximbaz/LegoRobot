using System;
using System.Threading;
using System.Windows;
using UI.ViewModels;

namespace UI
{
    public partial class App
    {
        #region Static Fields and Constants

        private static readonly Mutex Mutex = new Mutex(true, "{cb9fecbc-c300-45f3-9818-fa39c05a0b4b}");

        #endregion

        #region Protected And Private Methods

        private void OnStartup(object sender, StartupEventArgs e) {
            if (Mutex.WaitOne(TimeSpan.Zero, true)) {
                new MainWindow {DataContext = MainViewModel.Current}.Show();
                Mutex.ReleaseMutex();
            }
            else {
                MessageBox.Show("Program is already running.");
            }
        }

        #endregion
    }
}