using System;

namespace LegoRobot.Routing
{
    public class Start
    {
        public Guid Id { get; set; }
        public Guid PositionId { get; set; }
        public Guid OffsetId { get; set; }

        public Point Position { get; set; }
        public Point Offset { get; set; }
    }
}