using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaSolution.Data.Entities
{
    public class ProductLanguage
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public string? TitleSite { get; set; }
        public string? MetaKeywords { get; set; }
        public string? MetaDescription { get; set; }
        public int ProductId { get; set; }
        public string? LanguageCode { get; set; }
        public Product? Product { get; set; }
        public Language? Language { get; set; }

    }
}
