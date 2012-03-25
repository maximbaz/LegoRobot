using System.Data.Entity.ModelConfiguration;
using LegoRobot.Model.Routing;

namespace LegoRobot.Model.Configuration
{
    public class PointRoutesConfiguration : EntityTypeConfiguration<PointRoutes>
    {
        public PointRoutesConfiguration() {
            HasRequired(a => a.Point)
                .WithMany(a => a.Routes)
                .HasForeignKey(b => b.PointId)
                .WillCascadeOnDelete();

            HasRequired(a => a.Route)
                .WithMany(a => a.Points)
                .HasForeignKey(b => b.RouteId)
                .WillCascadeOnDelete(false);
        }
    }
}
