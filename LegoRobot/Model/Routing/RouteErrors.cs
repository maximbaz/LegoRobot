using System;
using System.ComponentModel.DataAnnotations;

namespace LegoRobot.Model.Routing
{
    public class RouteErrors
    {
        [Key, Column(Order = 0)] public Guid RouteId { get; set; }
        [Key, Column(Order = 1)] public Guid PointId { get; set; }

        public virtual Route Route { get; set; }
        public virtual Point Point { get; set; }
    }
}