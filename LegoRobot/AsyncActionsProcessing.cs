using System;
using System.Collections.Generic;
using System.Threading;

namespace LegoRobot
{
    public class AsyncActionsProcessing
    {
        #region Properties and Indexers

        public Queue<Action> Actions { get; set; }
        public bool PreparingToStop { get; set; }
        public int Delay { get; set; }
        public bool CanProcessActions { get; set; }

        #endregion

        #region Constructors and Destructor

        public AsyncActionsProcessing() {
            Actions = new Queue<Action>();
            new Thread(Bootstrap) {IsBackground = true}.Start();
        }

        #endregion

        #region Protected And Private Methods

        private void Bootstrap() {
            while (!PreparingToStop) {
                if (CanProcessActions)
                    ProcessWaitingActions();

                Thread.Sleep(Delay);
            }
        }

        private void ProcessWaitingActions() {
            while (Actions.Count > 0)
                Actions.Dequeue()();
        }

        #endregion
    }
}