using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Utils;

namespace lejOS
{
    public class Server
    {
        #region Events

        public event Action Started;

        #endregion

        #region Fields

        private readonly AsyncActionsProcessing actionsProcessing = new AsyncActionsProcessing();

        private readonly Process server = new Process {
            StartInfo = new ProcessStartInfo {
                FileName = "StartConnection.bat",
                WorkingDirectory = @"D:\Projects\Study\LegoRobot\JavaServer\bin",
                UseShellExecute = true,
//                WindowStyle = ProcessWindowStyle.Hidden
            }
        };

        #endregion

        #region Constructors and Destructor

        public Server() {
            server.EnableRaisingEvents = true;
            server.Exited += OnExit;
        }

        ~Server() {
            actionsProcessing.PreparingToStop = true;

            if (!server.HasExited)
                server.Kill();

            actionsProcessing.CanProcessActions = false;
        }

        #endregion

        #region Public Methods

        public void Invoke(Action action) {
            actionsProcessing.Actions.Enqueue(action);
        }

        public void Start() {
            if (actionsProcessing.CanProcessActions)
                return;

            server.Start();
            new Thread(RaiseStartedEvent).Start();
        }

        public void RefreshQueue() {
            actionsProcessing.Actions = new Queue<Action>();
        }

        #endregion

        #region Protected And Private Methods

        private void RaiseStartedEvent() {
            Thread.Sleep(1000); // Waiting while server connects to robot

            actionsProcessing.CanProcessActions = true;
            if (Started != null)
                Started();
        }

        private void OnExit(object sender, EventArgs args) {
            actionsProcessing.CanProcessActions = false;

            if (!actionsProcessing.PreparingToStop)
                Start();
        }

        #endregion
    }
}