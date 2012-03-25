using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LegoRobot.Model.Routing
{
    public class Route
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid StartId { get; set; }

        public double Scale { get; set; }
        public virtual Start Start { get; set; }
        public virtual List<PointRoutes> Points { get; set; }
    }
}
