using MetaSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaSolution.Data.Configurations
{
    public class ActionInModuleConfiguration : IEntityTypeConfiguration<ActionInModule>
    {
        public void Configure(EntityTypeBuilder<ActionInModule> builder)
        {
            builder.ToTable("ActionInModules");

            builder.HasKey(x => new { x.ModuleId, x.ActionId });

            builder.HasOne(x => x.Module).WithMany(x => x.ActionInModules).HasForeignKey(x => x.ModuleId);

            builder.HasOne(x => x.Action).WithMany(x => x.ActionInModules).HasForeignKey(x => x.ActionId);
        }
    }
}
