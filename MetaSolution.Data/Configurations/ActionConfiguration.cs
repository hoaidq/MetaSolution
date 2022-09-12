using Action = MetaSolution.Data.Entities.Action;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaSolution.Data.Configurations
{
    public class ActionConfiguration : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.ToTable("Actions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);

            builder.Property(x => x.Code).IsRequired().IsUnicode(false).HasMaxLength(64);

            builder.Property(x => x.Description).HasMaxLength(256);
        }
    }
}
