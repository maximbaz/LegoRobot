using System.Data.Entity.ModelConfiguration;
using Model.Routing;

namespace Model.Configuration
{
    public class StepConfiguration : EntityTypeConfiguration<Step>
    {
        #region Constructors and Destructor

        public StepConfiguration() {
            HasRequired(a => a.Point)
                .WithMany()
                .WillCascadeOnDelete(false);
        }

        #endregion
    }
}