using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Routing
{
    public class Route
    {
        #region Properties and Indexers

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid StartId { get; set; }
        public double Scale { get; set; }

        public virtual Start Start { get; set; }
        public virtual IList<Step> Steps { get; set; }

        #endregion
    }
}