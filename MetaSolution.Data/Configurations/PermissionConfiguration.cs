using MetaSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaSolution.Data.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions");

            builder.HasKey(x => new { x.RoleId, x.ModuleId, x.ActionId });

            builder.HasOne(x => x.Role).WithMany(x => x.Permissions).HasForeignKey(x => x.RoleId);

            builder.HasOne(x => x.Module).WithMany(x => x.Permissions).HasForeignKey(x => x.ModuleId);

            builder.HasOne(x => x.Action).WithMany(x => x.Permissions).HasForeignKey(x => x.ActionId);
        }
    }
}
