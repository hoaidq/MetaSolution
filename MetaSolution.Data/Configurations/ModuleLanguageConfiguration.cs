using MetaSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaSolution.Data.Configurations
{
    public class ModuleLanguageConfiguration : IEntityTypeConfiguration<ModuleLanguage>
    {
        public void Configure(EntityTypeBuilder<ModuleLanguage> builder)
        {
            builder.ToTable("ModuleLanguages");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(128);

            builder.Property(x => x.Description).HasMaxLength(256);

            builder.Property(x => x.LanguageCode).IsRequired().IsUnicode(false).HasMaxLength(5);

            builder.Property(x => x.ModuleId).IsRequired();

            builder.HasOne(x => x.Language).WithMany(x => x.ModuleLanguages).HasForeignKey(x => x.LanguageCode);

            builder.HasOne(x => x.Module).WithMany(x => x.ModuleLanguages).HasForeignKey(x => x.ModuleId);
        }
    }
}
