using System;
using System.Collections.Generic;
using System.Linq;
using LegoRobot.Model;
using LegoRobot.Model.Routing;

namespace LegoRobot
{
    public static class Db
    {
        #region Static Fields and Constants

        private static readonly AsyncActionsProcessing ActionsProcessing = new AsyncActionsProcessing();
        private static readonly RouteContext Context = new RouteContext();

        #endregion

        #region Constructors and Destructor

        static Db() {
            ActionsProcessing.CanProcessActions = true;
        }

        #endregion

        #region Public Methods

        public static void RoutePassed(Route route) {
            Invoke(() => Context.Log.Add(new Log {Route = route, Time = DateTime.Now, Succeed = true}));
            Invoke(() => Context.SaveChanges());
        }

        public static void RouteError(Guid routeId, Guid pointId) {
            Invoke(() => Context.RouteErrors.Add(new RouteErrors {RouteId = routeId, PointId = pointId}));
            Invoke(() => Context.Log.Add(new Log {RouteId = routeId, Time = DateTime.Now, Succeed = false}));
            Invoke(() => Context.SaveChanges());
        }

        public static void FillDbWithFakeRoute() {
            var route = new Route {Scale = 10};

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
            Context.Starts.Add(new Start {Position = new Point(0, 0), Offset = new Point(1, 1)});

            for (var i = 0; i < points.Count; i++) {
                Context.Points.Add(points[i]);
                Context.PointRoutes.Add(new PointRoutes {Index = i, Point = points[i], Route = route});
            }

            Context.SaveChanges();
        }

        public static void PassFirstRoute(Action<Route> callback) {
            Invoke(() => {
                var route = (from r in Context.Routes select r).First();
                callback(route);
            });
        }

        #endregion

        #region Protected And Private Methods

        private static void Invoke(Action action) {
            ActionsProcessing.Actions.Enqueue(action);
        }

        #endregion
    }
}