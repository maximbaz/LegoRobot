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

        public static void RouteError(Guid stepId, Guid routeId, Action<Guid> callback) {
            Invoke(() => {
                var error = new Error {StepId = stepId};
                Context.Errors.Add(error);
                Context.Log.Add(new Log {RouteId = routeId, Finish = DateTime.Now, Succeed = false});
                Context.SaveChanges();
                callback(error.Id);
            });
        }

        public static void SelectAllRoutes(Action<IEnumerable<Route>> callback) {
            Invoke(() => callback(from r in Context.Routes select r));
        }

        public static void GetRouteById(Guid id, Action<Route> callback) {
            Invoke(() => callback(Context.Routes.AsEnumerable().Single(r => r.Id == id)));
        }

        #endregion

        #region Protected And Private Methods

        private static void Invoke(Action action) {
            ActionsProcessing.Actions.Enqueue(action);
        }

        #endregion
    }
}