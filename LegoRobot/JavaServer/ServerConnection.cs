using System.Threading;

namespace LegoRobot.JavaServer
{
    public static class ServerConnection
    {
        public static void ProcessActions(object settings) {
            while (true) {
                var preparingToStop = ((ServerSettings) settings).PreparingToStop;
                var isStarted = ((ServerSettings) settings).IsStarted;

                if (isStarted)
                    ProcessWaitingActions(settings);

                if (preparingToStop)
                    return;

                Thread.Sleep(1000);
            }
        }

        private static void ProcessWaitingActions(object settings) {
            while (((ServerSettings) settings).Actions.Count > 0)
                ((ServerSettings) settings).Actions.Dequeue()();
        }
    }
}