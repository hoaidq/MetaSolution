using MetaSolution.Data.Entities;
using MetaSolution.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaSolution.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");

            builder.Property(x => x.PromotionPrice).HasColumnType("decimal(18,2)"); ;

            builder.Property(x => x.Image).HasMaxLength(128);

            builder.Property(x => x.ImageThumb).HasMaxLength(128);

            builder.Property(x => x.DateCreated).HasDefaultValue(DateTime.UtcNow);

            builder.Property(x => x.Status).HasDefaultValue(Status.Active);
        }
    }
}
