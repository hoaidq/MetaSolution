﻿using MetaSolution.Data.Enums;

namespace MetaSolution.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal PromotionPrice { get; set; }
        public string? Image { get; set; }
        public string? ImageThumb { get; set; }
        public int ViewCount { get; set; }
        public int Warranty { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int UserModified { get; set; }
        public Status Status { get; set; }
        public int CatalogId { get; set; }
        public List<ProductInCatalog>? ProductInCatalogs { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
        public List<ProductMedia>? ProductMedias { get; set; }
        public List<ProductLanguage>? ProductLanguages { get; set; }
        public List<AttributeValueInProduct>? AttributeValueInProducts { get; set; }
        public List<Cart>? Carts { get; set; }
    }
}
