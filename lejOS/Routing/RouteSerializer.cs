﻿using System;
using System.Collections.Generic;
using Model.Routing;

namespace lejOS.Routing
{
    public static class RouteSerializer
    {
        #region Static Fields and Constants

        private const double AngleEpsilon = 1;
        private const int Millimeters = 1000;

        #endregion

        #region Public Methods

        public static Queue<string> Serialize(Route route) {
            var result = new Queue<string>();
            if (route == null || route.Steps == null || route.Steps.Count < 1 ||
                route.Start == null || route.Start.Offset == null || route.Start.Position == null)
                return result;

            Point current = route.Start.Position,
                  previous = route.Start.Offset,
                  next = route.Steps[0].Point;

            for (var i = 0; i < route.Steps.Count; i++) {
                if (i > 0) {
                    current = route.Steps[i - 1].Point;
                    previous = i == 1
                                   ? route.Start.Position
                                   : route.Steps[i - 2].Point;
                    next = route.Steps[i].Point;
                }

                var currentVector = new Vector(previous, current);
                var nextVector = new Vector(current, next);
                if (i == 0)
                    currentVector.InvertDirection();
                var angle = currentVector.AngleBetween(nextVector);
                if (Math.Abs(angle) > AngleEpsilon)
                    result.Enqueue(RotateCommand(angle, route.Id.ToString(), current.Id.ToString()));

                result.Enqueue(MoveCommand(nextVector.Absolute(), route.Scale, route.Id.ToString(), current.Id.ToString()));
            }

            return result;
        }

        #endregion

        #region Protected And Private Methods

        private static string RotateCommand(double angle, string route, string point) {
            return string.Format("SRT={0:0.0} | Route={1} | Point={2}\n", angle, route, point);
        }

        private static string MoveCommand(double length, double scale, string route, string point) {
            return string.Format("SRD={0:0.0} | Route={1} | Point={2}\n", length * scale * Millimeters, route, point);
        }

        #endregion
    }
}