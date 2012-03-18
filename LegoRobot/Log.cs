using System;
using LegoRobot.Routing;

namespace LegoRobot
{
    public class Log
    {
        public Guid Id { get; set; }
        public Guid RouteId { get; set; }

        public DateTime Start { get; set; }
        public bool Suceed { get; set; }
        public Route Route { get; set; }
    }
}