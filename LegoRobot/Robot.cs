using System;
using LegoRobot.Model.Routing;

namespace LegoRobot
{
    public class Robot : IDisposable
    {
        public Robot() {
            Reconnect();
        }

        public bool IsConnected { get; private set; }

        public bool PassRoute(Route route) {
            throw new NotImplementedException();
        }

        public void Reconnect()
        {
            Disconnect();
            Connect(); // Todo: Start in parallel
        }

        public void Dispose()
        {
            Disconnect();
        }

        private void Connect()
        {
            throw new NotImplementedException();
        }

        private void Disconnect() {
            if (!IsConnected)
                return;
            throw new NotImplementedException();
        }
    }
}