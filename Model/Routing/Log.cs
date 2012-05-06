using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Routing
{
    public class Log
    {
        #region Properties and Indexers

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid RouteId { get; set; }
        public DateTime Finish { get; set; }
        public bool Succeed { get; set; }
        
        public virtual Route Route { get; set; }

        #endregion
    }
}