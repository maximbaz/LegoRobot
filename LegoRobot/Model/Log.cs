using System;
using System.ComponentModel.DataAnnotations;
using LegoRobot.Model.Routing;

namespace LegoRobot.Model
{
    public class Log
    {
        #region Properties and Indexers

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid RouteId { get; set; }

        public DateTime Time { get; set; }
        public bool Succeed { get; set; }
        public Route Route { get; set; }

        #endregion
    }
}