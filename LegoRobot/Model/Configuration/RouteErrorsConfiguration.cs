using System.Data.Entity.ModelConfiguration;
using LegoRobot.Model.Routing;

namespace LegoRobot.Model.Configuration
{
    public class RouteErrorsConfiguration : EntityTypeConfiguration<RouteErrors>
    {
        #region Constructors and Destructor

        public RouteErrorsConfiguration() {
            HasRequired(a => a.Point)
                .WithMany()
                .HasForeignKey(b => b.PointId)
                .WillCascadeOnDelete(false);
        }

        #endregion
    }
}