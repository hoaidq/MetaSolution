using MetaSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaSolution.Data.Configurations
{
    public class AttributeValueLanguageConfiguration : IEntityTypeConfiguration<AttributeValueLanguage>
    {
        public void Configure(EntityTypeBuilder<AttributeValueLanguage> builder)
        {
            builder.ToTable("AttributeValueLanguages");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Value).IsRequired().HasMaxLength(128);

            builder.Property(x => x.AttributeValueId).IsRequired();

            builder.Property(x => x.LanguageCode).IsRequired().IsUnicode(false).HasMaxLength(5);

            builder.HasOne(x => x.Language).WithMany(x => x.AttributeValueLanguages).HasForeignKey(x => x.LanguageCode);

            builder.HasOne(x => x.AttributeValue).WithMany(x => x.AttributeValueLanguages).HasForeignKey(x => x.AttributeValueId);
        }
    }
}
