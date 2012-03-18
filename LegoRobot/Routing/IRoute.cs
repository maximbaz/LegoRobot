using System;
using System.Collections.Generic;

namespace LegoRobot.Routing
{
    public interface IRoute
    {
        Guid Id { get; }
        Guid StartId { get; }

        Start Start { get; set; }
        double Scale { get; set; }
        List<PointRoutes> Points { get; }
    }
}
