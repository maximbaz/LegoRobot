using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace Utils
{
    public class SocketListener
    {
        #region Events

        public event Action<string> Received;

        #endregion

        #region Fields

        private readonly TcpListener listener;

        private readonly Thread worker;

        #endregion

        #region Constructors and Destructor

        public SocketListener(int port) {
            listener = new TcpListener(port);
            listener.Start();

            worker = new Thread(Listen);
            worker.Start();
        }

        #endregion

        #region Public and Internal Properties and Indexers

        public bool Working { get; set; }

        #endregion

        #region Protected And Private Methods

        private void Listen() {
            while (true) {
                if (!Working || Received == null) {
                    continue;
                }

                using (var socket = listener.AcceptSocket())
                using (var stream = new NetworkStream(socket))
                using (var reader = new StreamReader(stream)) {
                    var data = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(data)) {
                        Received(data);
                    }
                    reader.Close();
                    socket.Close();
                }
            }
        }

        #endregion
    }
}