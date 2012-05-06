using System.Data.Entity;
using Model.Configuration;
using Model.Routing;

namespace Model
{
    public class RouteContext : DbContext
    {
        #region Properties and Indexers

        public DbSet<Log> Log { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Start> Starts { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Error> Errors { get; set; }

        #endregion

        #region Constructors and Destructor

        public RouteContext() : base("LegoRobot") {}

        #endregion

        #region Protected And Private Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations
                .Add(new StepConfiguration())
                .Add(new StartConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}