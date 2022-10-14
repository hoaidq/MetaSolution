using MetaSolution.Data.Enums;

namespace MetaSolution.Data.Entities
{
    public class Catalog
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public bool IsShowOnHome { get; set; }
        public int SortOrder { get; set; }
        public Status Status { get; set; }
        public List<ProductInCatalog>? ProductInCatalogs { get; set; }
        public List<CatalogLanguage>? CatalogLanguages { get; set; }
    }
}