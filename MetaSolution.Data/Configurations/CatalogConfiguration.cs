using MetaSolution.Data.Entities;
using MetaSolution.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaSolution.Data.Configurations
{
    public class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {
            builder.ToTable("Catalogs");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.ParentId).HasDefaultValue(0);

            builder.Property(x => x.SortOrder).HasDefaultValue(1);

            builder.Property(x => x.Status).HasDefaultValue(Status.Active);
        }
    }
}
