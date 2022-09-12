using MetaSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaSolution.Data.Configurations
{
    public class CatalogLanguageConfiguration : IEntityTypeConfiguration<CatalogLanguage>
    {
        public void Configure(EntityTypeBuilder<CatalogLanguage> builder)
        {
            builder.ToTable("CatalogLanguages");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Title).IsRequired(true).HasMaxLength(128);

            builder.Property(x => x.TitleSite).IsRequired(true).HasMaxLength(128);

            builder.Property(x => x.MetaKeywords).HasMaxLength(128);

            builder.Property(x => x.MetaDescription).HasMaxLength(256);

            builder.Property(x => x.LanguageCode).IsRequired().IsUnicode(false).HasMaxLength(5);

            builder.Property(x => x.CatalogId).IsRequired();

            builder.HasOne(x => x.Language).WithMany(x => x.CatalogLanguages).HasForeignKey(x => x.LanguageCode);

            builder.HasOne(x => x.Catalog).WithMany(x => x.CatalogLanguages).HasForeignKey(x => x.CatalogId);
        }
    }
}
