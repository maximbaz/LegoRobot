using System.Data.Entity;
using LegoRobot.Model.Configuration;
using LegoRobot.Model.Routing;

namespace LegoRobot.Model
{
    public class RouteContext : DbContext
    {
        #region Properties and Indexers

        public DbSet<Route> Routes { get; set; }
        public DbSet<Start> Starts { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<PointRoutes> PointRoutes { get; set; }
        public DbSet<RouteErrors> RouteErrors { get; set; }

        #endregion

        #region Protected And Private Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations
                .Add(new StartConfiguration())
                .Add(new PointRoutesConfiguration())
                .Add(new RouteErrorsConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}