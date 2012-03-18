using System.Data.Entity;
using LegoRobot.Routing;

namespace LegoRobot
{
    public class RouteContext : DbContext
    {
        public DbSet<Route> Routes { get; set; }
        public DbSet<Start> Starts { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<PointRoutes> PointRoutes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Start>()
                        .HasRequired(a => a.Offset)
                        .WithMany()
                        .HasForeignKey(u => u.OffsetId)
                        .WillCascadeOnDelete(false);

//            modelBuilder.Entity<PointRoutes>()
//                        .HasRequired(a => a.Route)
//                        .WithMany()
//                        .HasForeignKey(u => u.RouteId)
//                        .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
