using MetaSolution.Data.Configurations;
using MetaSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.ApplyConfiguration(new CatalogConfiguration());

            modelBuilder.ApplyConfiguration(new CatalogLanguageConfiguration());

            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.ApplyConfiguration(new ProductLanguageConfiguration());

            modelBuilder.ApplyConfiguration(new ProductInCatalogConfiguration());

            modelBuilder.ApplyConfiguration(new ProductMediaConfiguration());

            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());

            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
        }

        public DbSet<Catalog>? Catalogs { get; set; }
        public DbSet<CatalogLanguage>? CatalogLanguages { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductLanguage>? ProductLanguages { get; set; }
        public DbSet<ProductInCatalog>? ProductInCatalogs { get; set; }
        public DbSet<ProductMedia>? ProductImages { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderDetail>? OrderDetails { get; set; }
        public DbSet<Language>? Languages { get; set; }
    }
}
