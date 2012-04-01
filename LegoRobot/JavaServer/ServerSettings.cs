using System;
using System.Collections.Generic;

namespace LegoRobot.JavaServer
{
    public class ServerSettings
    {
        public Queue<Action> Actions { get; set; }
        public bool PreparingToStop { get; set; }
        public bool IsStarted { get; set; }
    }
}