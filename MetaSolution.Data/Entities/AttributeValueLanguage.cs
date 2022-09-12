using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaSolution.Data.Entities
{
    public class AttributeValueLanguage
    {
        public int Id { get; set; }
        public string? Value { get; set; }
        public int AttributeValueId { get; set; }
        public string? LanguageCode { get; set; }
        public AttributeValue? AttributeValue { get; set; }
        public Language? Language { get; set; }
    }
}
