using System;
using System.ComponentModel.DataAnnotations;

namespace LegoRobot.Model.Routing
{
    public class Start
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid PositionId { get; set; }
        public Guid OffsetId { get; set; }

        public virtual Point Position { get; set; }
        public virtual Point Offset { get; set; }
    }
}