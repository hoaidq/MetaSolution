using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaSolution.Data.Entities
{
    public class ModuleLanguage
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? LanguageCode { set; get; }
        public Language? Language { get; set; }
        public int ModuleId { set; get; }
        public Module? Module { get; set; }
    }
}
