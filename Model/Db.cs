using System;
using System.Collections.Generic;
using System.Linq;
using Model.Routing;
using Utils;

namespace Model
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
            Invoke(() => {
                Context.Log.Add(new Log {Route = route, Finish = DateTime.Now, Succeed = true});
                Context.SaveChanges();
            });
        }

        public static void RouteError(Guid stepId, Guid routeId) {
            Invoke(() => {
                Context.Errors.Add(new Error {StepId = stepId});
                Context.Log.Add(new Log {RouteId = routeId, Finish = DateTime.Now, Succeed = false});
                Context.SaveChanges();
            });
        }

        public static void FillDbWithFakeRoute() {
            var points = new List<Point> {
                new Point(0, 2),
                new Point(1, 3),
                new Point(4, 3),
                new Point(4, 6),
                new Point(2, 8),
                new Point(0, 8),
                new Point(0, 10)
            };

            var route = new Route {
                Scale = 10,
                Start = new Start {Position = new Point(0, 0), Offset = new Point(1, 1)}
            };

            var steps = new List<Step> {
                new Step {Point = points[0], Order = 1, Route = route},
                new Step {Point = points[1], Order = 2, Route = route},
                new Step {Point = points[2], Order = 3, Route = route},
                new Step {Point = points[3], Order = 4, Route = route},
                new Step {Point = points[4], Order = 5, Route = route},
                new Step {Point = points[5], Order = 6, Route = route},
                new Step {Point = points[6], Order = 7, Route = route},
            };

            Context.Routes.Add(route);
            foreach (var step in steps) {
                Context.Steps.Add(step);
            }

            Context.SaveChanges();
        }

        public static void PassFirstRoute(Action<Route> callback) {
            Invoke(() => {
                var route = (from r in Context.Routes select r).First();
                callback(route);
            });
        }

        public static void SelectAllRoutes(Action<IEnumerable<Route>> callback) {
            Invoke(() => callback(from r in Context.Routes select r));
        }

        public static void GetAllLogs(Action<IEnumerable<Log>> callback) {
            Invoke(() => callback(from l in Context.Log select l));
        }

        #endregion

        #region Protected And Private Methods

        private static void Invoke(Action action) {
            ActionsProcessing.Actions.Enqueue(action);
        }

        #endregion
    }
}