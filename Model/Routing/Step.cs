using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Routing
{
    public class Step
    {
        #region Properties and Indexers

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid PointId { get; set; }
        public Guid RouteId { get; set; }
        public int Order{ get; set; }

        public virtual Point Point { get; set; }
        public virtual Route Route { get; set; }

        #endregion
    }
}