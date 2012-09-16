using System;
using System.Collections.Generic;
using System.Linq;
using Model.Routing;

namespace lejOS.Routing
{
    public static class RouteSerializer
    {
        #region Static Fields and Constants

        private const double AngleEpsilon = 1;
        private const int Santimeters = 100;

        #endregion

        #region Public Methods

        public static Queue<string> Serialize(Route route) {
            var result = new Queue<string>();
            if (route == null || route.Steps == null || route.Steps.Count < 1 ||
                route.Start == null || route.Start.Offset == null || route.Start.Position == null)
                return result;

            var steps = route.Steps.OrderByDescending(x => x.Order).ToList();
            Point current = route.Start.Position,
                  previous = route.Start.Offset,
                  next = steps[0].Point;

            for (var i = 0; i < steps.Count; i++) {
                if (i > 0) {
                    current = steps[i - 1].Point;
                    previous = i == 1
                                   ? route.Start.Position
                                   : steps[i - 2].Point;
                    next = steps[i].Point;
                }

                var currentVector = new Vector(previous, current);
                var nextVector = new Vector(current, next);
                if (i == 0)
                    currentVector.InvertDirection();
                var angle = currentVector.AngleBetween(nextVector);
                if (Math.Abs(angle) > AngleEpsilon)
                    result.Enqueue(RotateCommand(angle, route.Id.ToString(), steps[i].Id.ToString()));

                result.Enqueue(MoveCommand(nextVector.Absolute(), route.Scale, route.Id.ToString(), steps[i].Id.ToString()));
            }

            return result;
        }

        #endregion

        #region Protected And Private Methods

        private static string RotateCommand(double angle, string route, string point) {
            return string.Format("SRT={0:0.0} | Route={1} | Step={2}\n", angle, route, point);
        }

        private static string MoveCommand(double length, double scale, string route, string point) {
            return string.Format("SRD={0:0.0} | Route={1} | Step={2}\n", length * scale * Santimeters, route, point);
        }

        #endregion
    }
}