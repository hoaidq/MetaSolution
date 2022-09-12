using MetaSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetaSolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Config>().HasData(
                new Config() { Key = "HomeTitle", Value = "This is homepage of Meta Solution" },
                new Config() { Key = "HomeKeyword", Value = "This is keyword of Meta Solution" },
                new Config() { Key = "HomeDescription", Value = "This is description of Meta Solution" }
            );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Code = "vi-VN", Name = "Tiếng Việt" },
                new Language() { Code = "en-US", Name = "English" }
            );

            modelBuilder.Entity<Catalog>().HasData(
                new Catalog() { Id = 1, ParentId = null, SortOrder = 1, Status = Enums.Status.Active }
            );
        }
    }
}
