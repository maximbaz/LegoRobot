using System;
using LegoRobot.Model.Routing;

namespace LegoRobot.JavaServer.Route
{
    public class Vector
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Vector(Point first, Point second) {
            X = second.X - first.X;
            Y = second.Y - first.Y;
        }

        public double Absolute() {
            return Math.Sqrt(X * X + Y * Y);
        }

        public int AngleBetween(Vector vector) {
            return ToDegrees(ComputeAngle(vector)) * AngleSign(vector);
        }

        public double ComputeAngle(Vector vector) {
            return Math.Acos((X * vector.X + Y * vector.Y) / (Absolute() * vector.Absolute()));
        }

        private int AngleSign(Vector vector) {
            return (X * vector.Y > Y * vector.X) ? -1 : 1;
        }

        private static int ToDegrees(double radians) {
            return (int) (radians * 180 / Math.PI);
        }

        public void InvertDirection() {
            X *= -1;
            Y *= -1;
        }
    }
}
