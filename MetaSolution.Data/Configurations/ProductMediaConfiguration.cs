using MetaSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaSolution.Data.Configurations
{
    public class ProductMediaConfiguration : IEntityTypeConfiguration<ProductMedia>
    {
        public void Configure(EntityTypeBuilder<ProductMedia> builder)
        {
            builder.ToTable("ProductMedias");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Title).HasMaxLength(128);

            builder.Property(x => x.Path).IsRequired().HasMaxLength(256);

            builder.Property(x => x.IsDefault).HasDefaultValue(false);

            builder.Property(x => x.DateCreated).HasDefaultValue(DateTime.UtcNow);

            builder.HasOne(x => x.Product).WithMany(x => x.ProductMedias).HasForeignKey(x => x.ProductId);
        }
    }
}
