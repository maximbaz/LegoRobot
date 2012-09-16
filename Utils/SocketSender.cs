using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace Utils
{
    public class SocketSender
    {
        #region Fields

        private bool active;
        private int port;
        private TcpClient client;
        private readonly Thread worker;
        private readonly Queue<string> queue;
        private bool tryingToConnect;

        #endregion

        #region Constructors and Destructor

        public SocketSender(int port) {
            this.port = port;
            queue = new Queue<string>();
            worker = new Thread(TryConnect);
            worker.Start();
        }

        #endregion

        private void TryConnect() {
            tryingToConnect = true;
            while (!active) {
                try {
                    client = new TcpClient("5.183.186.121", port);
                    active = true;
                    tryingToConnect = false;
                    CleanQueue();
                }
                catch (SocketException) {}
            }
        }

        private void CleanQueue() {
            while (queue.Count > 0) {
                Send(queue.Dequeue());
            }
        }

        #region Public and Internal Methods

        public void Send(string data) {
            if (!active) {
                queue.Enqueue(data);
                if (!tryingToConnect) {
                    TryConnect();
                }
                return;
            }

            try {
                using (var stream = client.GetStream())
                using (var writer = new StreamWriter(stream))
                {
                    writer.AutoFlush = true;
                    writer.WriteLine(data);
                    writer.Close();
                }
            } 
            catch (InvalidOperationException) {
                active = false;
                queue.Enqueue(data);
                TryConnect();
            }
            
        }

        #endregion
    }
}