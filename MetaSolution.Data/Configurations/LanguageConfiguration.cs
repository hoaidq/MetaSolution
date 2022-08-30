using MetaSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaSolution.Data.Configurations
{
    internal class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages");

            builder.HasKey(x => x.Code);

            builder.Property(x => x.Code).IsRequired().IsUnicode(false).HasMaxLength(5);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);

            builder.Property(x => x.Description).HasMaxLength(256);
        }
    }
}
