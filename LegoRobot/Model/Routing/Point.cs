﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LegoRobot.Model.Routing
{
    public class Point
    {
        public Point() : this(0, 0) {}

        public Point(double x, double y) {
            X = x;
            Y = y;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public double X { get; set; }
        public double Y { get; set; }
        public virtual List<PointRoutes> Routes { get; set; }
    }
}