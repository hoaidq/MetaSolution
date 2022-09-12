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
    internal class ProductInCatalogConfiguration : IEntityTypeConfiguration<ProductInCatalog>
    {
        public void Configure(EntityTypeBuilder<ProductInCatalog> builder)
        {
            builder.ToTable("ProductInCatalogs");

            builder.HasKey(x => new { x.CatalogId, x.ProductId });

            builder.HasOne(x => x.Product).WithMany(x => x.ProductInCatalogs).HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Catalog).WithMany(x => x.ProductInCatalogs).HasForeignKey(x => x.CatalogId);
        }
    }
}
