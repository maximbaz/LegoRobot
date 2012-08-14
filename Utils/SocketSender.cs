using System.IO;
using System.Net.Sockets;

namespace Utils
{
    public class SocketSender
    {
        #region Fields

        private readonly bool active;
        private readonly TcpClient client;

        #endregion

        #region Constructors and Destructor

        public SocketSender(int port) {
            try {
                client = new TcpClient("127.0.0.1", port);
                active = true;
            }
            catch (SocketException) {}
        }

        #endregion

        #region Public and Internal Methods

        public void Send(string data) {
            if (!active) {
                return;
            }

            using (var stream = client.GetStream())
            using (var writer = new StreamWriter(stream)) {
                writer.AutoFlush = true;
                writer.WriteLine(data);
                writer.Close();
            }
        }

        #endregion
    }
}