using MetaSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaSolution.Data.Configurations
{
    public class AttributeValueInProductConfiguration : IEntityTypeConfiguration<AttributeValueInProduct>
    {
        public void Configure(EntityTypeBuilder<AttributeValueInProduct> builder)
        {
            builder.ToTable("AttributeValueInProducts");

            builder.HasKey(x => new { x.ProductId, x.AttributeValueId });

            builder.HasOne(x => x.Product).WithMany(x => x.AttributeValueInProducts).HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.AttributeValue).WithMany(x => x.AttributeValueInProducts).HasForeignKey(x => x.AttributeValueId);
        }
    }
}
