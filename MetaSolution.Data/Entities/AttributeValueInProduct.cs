using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaSolution.Data.Entities
{
    public class AttributeValueInProduct
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int AttributeValueId { get; set; }
        public AttributeValue? AttributeValue { get; set; }
    }
}