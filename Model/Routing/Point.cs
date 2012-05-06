using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Routing
{
    public class Point
    {
        #region Properties and Indexers

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public double X { get; set; }
        public double Y { get; set; }

        #endregion

        #region Constructors and Destructor

        public Point() : this(0, 0) {}

        public Point(double x, double y) {
            X = x;
            Y = y;
        }

        #endregion
    }
}