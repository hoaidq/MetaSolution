﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaSolution.Data.Entities
{
    public class ProductInCatalog
    {
        public int CatalogId { get; set; }
        public Catalog? Catalog { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
