using System;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using LegoRobot.JavaServer;
using LegoRobot.JavaServer.Route;
using LegoRobot.Model.Routing;

namespace LegoRobot
{
    public class Robot
    {
        private readonly RouteSerializer serializer = new RouteSerializer();
        private readonly Server server = new Server();
        private Socket socket;

        public Robot() {
            server.Started += CreateSocket;
            server.Start();
        }

        public void PassRoute(Route route) {
            foreach (var action in serializer.Serialize(route)) {
                server.Invoke(() => Send(action));
                server.Invoke(CheckAnswerIsOk);
            }

            server.Invoke(() => new Thread(() => Db.RoutePassed(route)).Start());
        }

        private void Send(string request) {
            var bytesSend = Encoding.ASCII.GetBytes(request);
            socket.Send(bytesSend, bytesSend.Length, 0);
        }

        private void CheckAnswerIsOk() {
            var answer = Receive();
            if (answer.StartsWith("OK"))
                return;

            server.RefreshQueue();
            new Thread(() => Db.RouteError(ParseAnswer(answer, "Route"), ParseAnswer(answer, "Point"))).Start();
        }

        private string Receive() {
            var bytesReceived = new byte[256];
            int bytes;
            var response = "";
            do {
                bytes = socket.Receive(bytesReceived, bytesReceived.Length, 0);
                response += Encoding.ASCII.GetString(bytesReceived, 0, bytes);
            }
            while (bytes > 0 && !response.EndsWith("\n"));

            return response.Substring(0, response.Length - 1);
        }

        private void CreateSocket() {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Invoke(() => socket.Connect("127.0.0.1", 20042));
        }

        private static Guid ParseAnswer(string answer, string value) {
            var regex = new Regex("(?<=" + value + @"=)[^\s]+");
            var captures = regex.Match(answer).Captures;
            return Guid.Parse(captures[0].Value);
        }
    }
}