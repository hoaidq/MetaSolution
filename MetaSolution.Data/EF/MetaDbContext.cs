using MetaSolution.Data.Configurations;
using MetaSolution.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Attribute = MetaSolution.Data.Entities.Attribute;
using Action = MetaSolution.Data.Entities.Action;
using MetaSolution.Data.Extensions;

namespace MetaSolution.Data.EF
{
    public class MetaDbContext : DbContext
    {
        public MetaDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API
            modelBuilder.ApplyConfiguration(new ConfigConfiguration());

            modelBuilder.ApplyConfiguration(new CatalogConfiguration());

            modelBuilder.ApplyConfiguration(new CatalogLanguageConfiguration());

            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.ApplyConfiguration(new ProductLanguageConfiguration());

            modelBuilder.ApplyConfiguration(new ProductInCatalogConfiguration());

            modelBuilder.ApplyConfiguration(new ProductMediaConfiguration());

            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());

            modelBuilder.ApplyConfiguration(new LanguageConfiguration());

            modelBuilder.ApplyConfiguration(new AttributeConfiguration());

            modelBuilder.ApplyConfiguration(new AttributeValueConfiguration());

            modelBuilder.ApplyConfiguration(new AttributeValueInProductConfiguration());

            modelBuilder.ApplyConfiguration(new AttributeValueLanguageConfiguration());

            modelBuilder.ApplyConfiguration(new CartConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.ApplyConfiguration(new UserInRoleConfiguration());

            modelBuilder.ApplyConfiguration(new ModuleConfiguration());

            modelBuilder.ApplyConfiguration(new ModuleLanguageConfiguration());

            modelBuilder.ApplyConfiguration(new ActionConfiguration());

            modelBuilder.ApplyConfiguration(new ActionInModuleConfiguration());

            modelBuilder.ApplyConfiguration(new PermissionConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaim");

            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogin").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserToken").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaim");

            //Data seeding
            modelBuilder.Seed();
        }

        public DbSet<Config>? Configs { get; set; }
        public DbSet<Catalog>? Catalogs { get; set; }
        public DbSet<CatalogLanguage>? CatalogLanguages { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductLanguage>? ProductLanguages { get; set; }
        public DbSet<ProductInCatalog>? ProductInCatalogs { get; set; }
        public DbSet<ProductMedia>? ProductImages { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderDetail>? OrderDetails { get; set; }
        public DbSet<Language>? Languages { get; set; }
        public DbSet<Attribute>? Attributes { get; set; }
        public DbSet<AttributeValue>? AttributeValues { get; set; }
        public DbSet<AttributeValueInProduct>? AttributeValueInProducts { get; set; }
        public DbSet<AttributeValueLanguage>? AttributeValueLanguages { get; set; }
        public DbSet<Cart>? Carts { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<UserInRole>? UserInRoles { get; set; }
        public DbSet<Module>? Modules { get; set; }
        public DbSet<ModuleLanguage>? ModuleLanguages { get; set; }
        public DbSet<Action>? Actions { get; set; }
        public DbSet<ActionInModule>? ActionsInModules { get; set; }
        public DbSet<Permission>? Permissions { get; set; }
    }
}