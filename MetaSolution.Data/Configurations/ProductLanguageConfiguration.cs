using MetaSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaSolution.Data.Configurations
{
    public class ProductLanguageConfiguration : IEntityTypeConfiguration<ProductLanguage>
    {
        public void Configure(EntityTypeBuilder<ProductLanguage> builder)
        {
            builder.ToTable("ProductLanguages");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Title).IsRequired().HasMaxLength(128);

            builder.Property(x => x.Description).HasMaxLength(256);

            builder.Property(x => x.Content).HasColumnType("ntext");

            builder.Property(x => x.TitleSite).IsRequired().HasMaxLength(128);

            builder.Property(x => x.MetaKeywords).HasMaxLength(128);

            builder.Property(x => x.MetaDescription).HasMaxLength(256);

            builder.Property(x => x.LanguageCode).IsRequired().IsUnicode(false).HasMaxLength(5);

            builder.HasOne(x => x.Language).WithMany(x => x.ProductLanguages).HasForeignKey(x => x.LanguageCode);

            builder.HasOne(x => x.Product).WithMany(x => x.ProductLanguages).HasForeignKey(x => x.ProductId);
        }
    }
}
