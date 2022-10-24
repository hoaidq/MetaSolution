using MetaSolution.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MetaSolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Config>().HasData(
                new Config() { Id = 1, Key = "HomeTitle", Value = "This is homepage of Meta Solution" },
                new Config() { Id = 2, Key = "HomeKeyword", Value = "This is keyword of Meta Solution" },
                new Config() { Id = 3, Key = "HomeDescription", Value = "This is description of Meta Solution" }
            );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Code = "vi-VN", Name = "Tiếng Việt" },
                new Language() { Code = "en-US", Name = "English" }
            );

            Guid roleID = new Guid("75F218BB-7F54-4276-83D2-61A97077F66B");
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = roleID,
                    Name = "Administrator",
                    NormalizedName = "admin",
                    Description = "Administrator Role"
                }
            );

            var hasher = new PasswordHasher<User>();
            Guid userID = new Guid("6EBFC0B1-B951-4A1D-8B76-8ACBE45ECD0E");
            _ = modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = userID,
                    UserName = "admin",
                    NormalizedUserName = "admin",
                    Email = "hoaidq@gmail.com",
                    NormalizedEmail = "hoaidq@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Abc@123"),
                    SecurityStamp = String.Empty,
                    FirstName = "Hoai",
                    LastName = "Dương",
                    Dob = new DateTime(1981, 2, 9)
                }
            );

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = roleID,
                    UserId = userID,
                }
            );

            modelBuilder.Entity<Module>().HasData(
                new Module
                {
                    Id = 1,
                    Code = "groups",
                    Level = 1,
                    Order = 1,
                    ParentId = null
                },
                new Module
                {
                    Id = 2,
                    Code = "users",
                    Level = 1,
                    Order = 2,
                    ParentId = null
                }
            );

            modelBuilder.Entity<ModuleLanguage>().HasData(
                new ModuleLanguage
                {
                    Id = 1,
                    Name = "Quản lý nhóm",
                    Description = "",
                    ModuleId = 1,
                    LanguageCode = "vi-VN"
                },
                new ModuleLanguage
                {
                    Id = 2,
                    Name = "Group manager",
                    Description = "",
                    ModuleId = 1,
                    LanguageCode = "en-US"
                },
                new ModuleLanguage
                {
                    Id = 3,
                    Name = "Quản lý thành viên",
                    Description = "",
                    ModuleId = 2,
                    LanguageCode = "vi-VN"
                },
                new ModuleLanguage
                {
                    Id = 4,
                    Name = "Member manager",
                    Description = "",
                    ModuleId = 2,
                    LanguageCode = "en-US"
                }
            );

            modelBuilder.Entity<Catalog>().HasData(
                new Catalog() { Id = 1, IsShowOnHome = true, ParentId = null, SortOrder = 1, Status = Enums.Status.Active },
                new Catalog() { Id = 2, IsShowOnHome = true, ParentId = null, SortOrder = 1, Status = Enums.Status.Active }
            );

            modelBuilder.Entity<CatalogLanguage>().HasData(
                new CatalogLanguage()
                {
                    Id = 1,
                    Title = "Điện thoại",
                    TitleSite = "Điện thoại di động",
                    MetaAlias = "dien-thoai",
                    MetaKeywords = "điện thoại, điện thoại di động",
                    MetaDescription = "Điện thoại di động",
                    CatalogId = 1,
                    LanguageCode = "vi-VN"
                },
                new CatalogLanguage()
                {
                    Id = 2,
                    Title = "Phone",
                    TitleSite = "Mobile phone",
                    MetaAlias = "mobile-phone",
                    MetaKeywords = "mobile phone",
                    MetaDescription = "mobile phone",
                    CatalogId = 1,
                    LanguageCode = "en-US"
                },
                new CatalogLanguage()
                {
                    Id = 3,
                    Title = "Phụ kiện",
                    TitleSite = "Phụ kiện di động",
                    MetaAlias = "phu-kien",
                    MetaKeywords = "phụ kiện, phụ kiện di động",
                    MetaDescription = "phụ kiện di động",
                    CatalogId = 2,
                    LanguageCode = "vi-VN"
                },
                new CatalogLanguage()
                {
                    Id = 4,
                    Title = "Accessory",
                    TitleSite = "Mobile accessory",
                    MetaAlias = "mobile-accessory",
                    MetaKeywords = "mobile accessory",
                    MetaDescription = "mobile accessory",
                    CatalogId = 2,
                    LanguageCode = "en-US"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Price = 12000000,
                    PromotionPrice = 10500000,
                    Warranty = 12,
                    DateCreated = DateTime.UtcNow,
                    UserCreated = "admin (hoaidq@gmail.com)",
                }
            );

            modelBuilder.Entity<ProductInCatalog>().HasData(
                new ProductInCatalog
                {
                    CatalogId = 1,
                    ProductId = 1
                }
            );

            modelBuilder.Entity<ProductLanguage>().HasData(
                new ProductLanguage
                {
                    Id = 1,
                    Title = "Điện thoại iPhone XS Max 64GB",
                    TitleSite = "Điện thoại iPhone XS Max 64GB",
                    Description = "",
                    Content = "",
                    MetaKeywords = "Điện thoại iPhone XS Max 64GB",
                    MetaDescription = "",
                    ProductId = 1,
                    LanguageCode = "vi-VN"
                },
                new ProductLanguage
                {
                    Id = 2,
                    Title = "iPhone XS Max 64GB",
                    TitleSite = "iPhone XS Max 64GB",
                    Description = "",
                    Content = "",
                    MetaKeywords = "iPhone XS Max 64GB",
                    MetaDescription = "",
                    ProductId = 1,
                    LanguageCode = "en-US"
                }
            );
        }
    }
}
