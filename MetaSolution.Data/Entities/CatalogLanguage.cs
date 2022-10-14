using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaSolution.Data.Entities
{
    public class CatalogLanguage
    {
        public int Id { set; get; }
        public string? Title { get; set; }
        public string? TitleSite { get; set; }
        public string? MetaKeywords { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaAlias { get; set; }
        public string? LanguageCode { set; get; }
        public Language? Language { get; set; }
        public int CatalogId { set; get; }
        public Catalog? Catalog { get; set; }
    }
}
