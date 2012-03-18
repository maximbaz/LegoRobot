using System;
using System.Collections.Generic;

namespace LegoRobot.Routing
{
    public class FakeRoute : IRoute
    {
        public FakeRoute() {
//            Id = Guid.NewGuid();
//            Start = new Start {Id = Guid.NewGuid(), Position = new Point(0, 0), Offset = new Point(1, 0) /*, Route = this */};
//
//            Points = new List<PointRoutes> {
//                new Point(1, 1), new Point(2, 2), new Point(2, 3)
//            };
        }

        public Guid Id { get; private set; }
        public Guid StartId { get; private set; }

        public List<PointRoutes> Points { get; private set; }
        public Start Start { get; set; }

        public double Scale { get; set; }
    }
}
