using System;
using System.ComponentModel.DataAnnotations;

namespace LegoRobot.Routing
{
    public class PointRoutes
    {
        [Key, Column(Order = 0)] public Guid PointId { get; set; }
        [Key, Column(Order = 1)] public Guid RouteId { get; set; }

        public int Index { get; set; }

        [ForeignKey("PointId")] public virtual Point Point { get; set; }
        [ForeignKey("RouteId")] public virtual Route Route { get; set; }
    }
}