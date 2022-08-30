using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaSolution.Data.Entities
{
    public class Language
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsDefault { get; set; }
        public List<ProductLanguage>? ProductLanguages { get; set; }
        public List<CatalogLanguage>? CatalogLanguages { get; set; }
    }
}
