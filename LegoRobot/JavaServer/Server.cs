using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace LegoRobot.JavaServer
{
    public class Server : IDisposable
    {
        public event Action Started;

        private readonly ServerSettings settings;

        private readonly Process server = new Process {
            StartInfo = new ProcessStartInfo {
                FileName = "StartConnection.bat",
                WorkingDirectory = @"D:\Projects\Study\LegoRobot\JavaServer\bin",
                UseShellExecute = true,
//                WindowStyle = ProcessWindowStyle.Hidden
            }
        };
        
        public Server() {
            server.EnableRaisingEvents = true;
            server.Exited += OnExit;

            settings = new ServerSettings {PreparingToStop = false, IsStarted = false};
            new Thread(ServerConnection.ProcessActions) {IsBackground = true}.Start(settings);

            RefreshQueue();
        }

        public void Invoke(Action action) {
            settings.Actions.Enqueue(action);
        }

        public void Start() {
            if (settings.IsStarted)
                return;

            server.Start();
            new Thread(RaiseEvent).Start();
        }

        public void RefreshQueue() {
            settings.Actions = new Queue<Action>();
        }

        public void Dispose() {
            settings.PreparingToStop = true;
            Stop();
            GC.SuppressFinalize(this);
        }
        
        ~Server() {
            settings.PreparingToStop = true;
            Stop();
        }

        private void RaiseEvent() {
            Thread.Sleep(1000);

            settings.IsStarted = true;
            if (Started != null)
                Started();
        }

        private void Stop() {
            if (!settings.IsStarted)
                return;

            server.Kill();
            settings.IsStarted = false;
        }

        private void OnExit(object sender, EventArgs args) {
            settings.IsStarted = false;

            if (!settings.PreparingToStop)
                Start();
        }
    }
}