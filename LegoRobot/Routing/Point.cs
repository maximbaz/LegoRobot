using System;

namespace LegoRobot.Routing
{
    public class Point
    {
        public Point() : this(0, 0) {}

        public Point(double x, double y) {
            X = x;
            Y = y;
        }

        public Guid Id { get; set; }

        public double X { get; set; }
        public double Y { get; set; }
    }
}