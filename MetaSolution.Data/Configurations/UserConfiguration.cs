using MetaSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaSolution.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(128);

            builder.Property(x => x.LastName).IsRequired().HasMaxLength(128);

            builder.Property(x => x.Dob).IsRequired();
        }
    }
}