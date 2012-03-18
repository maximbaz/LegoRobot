using System;
using System.Collections.Generic;

namespace LegoRobot.Routing
{
    public class Route : IRoute
    {
        public Guid Id { get; set; }
        public Guid StartId { get; set; }

        public double Scale { get; set; }
        public virtual Start Start { get; set; }
        public virtual List<PointRoutes> Points { get; set; }
    }
}
