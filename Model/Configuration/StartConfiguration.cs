using System.Data.Entity.ModelConfiguration;
using Model.Routing;

namespace Model.Configuration
{
    public class StartConfiguration : EntityTypeConfiguration<Start>
    {
        #region Constructors and Destructor

        public StartConfiguration() {
            HasRequired(a => a.Offset)
                .WithMany()
                .WillCascadeOnDelete(false);
        }

        #endregion
    }
}