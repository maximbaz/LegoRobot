using System;
using System.Collections.Generic;
using LegoRobot.Model;
using LegoRobot.Model.Routing;

namespace LegoRobot
{
    public static class Db
    {
        public static RouteContext Context { get; private set; }

        static Db() {
            Context = new RouteContext();
        }

        public static void RoutePassed(Route route) {
            Context.Log.Add(new Log { Route = route, Time = DateTime.Now, Succeed = true });
            Context.SaveChanges();
        }

        public static void RouteError(Guid routeId, Guid pointId) {
            Context.RouteErrors.Add(new RouteErrors {RouteId = routeId, PointId = pointId});
            Context.Log.Add(new Log { RouteId = routeId, Time = DateTime.Now, Succeed = false });
            Context.SaveChanges();
        }

        public static void FillDbWithFakeRoute()
        {
            var route = new Route { Scale = 10 };

            var points = new List<Point> {
                new Point(0, 2),
                new Point(1, 3),
                new Point(4, 3),
                new Point(4, 6),
                new Point(2, 8),
                new Point(0, 8),
                new Point(0, 10)
            };

            Context.Routes.Add(route);
            Context.Starts.Add(new Start { Position = new Point(0, 0), Offset = new Point(1, 1) });

            for (var i = 0; i < points.Count; i++) {
                Context.Points.Add(points[i]);
                Context.PointRoutes.Add(new PointRoutes { Index = i, Point = points[i], Route = route });
            }

            Context.SaveChanges();
        }
    }
}