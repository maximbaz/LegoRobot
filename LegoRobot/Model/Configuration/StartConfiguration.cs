using System.Data.Entity.ModelConfiguration;
using LegoRobot.Model.Routing;

namespace LegoRobot.Model.Configuration
{
    public class StartConfiguration : EntityTypeConfiguration<Start>
    {
        public StartConfiguration() {
            HasRequired(a => a.Offset)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}
