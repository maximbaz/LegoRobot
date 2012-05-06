using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Routing
{
    public class Error
    {
        #region Properties and Indexers

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid StepId { get; set; }
        public DateTime Time { get; set; }

        public virtual Step Step { get; set; }

        #endregion
    }
}