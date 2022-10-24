using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaSolution.ViewModels.Products
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public decimal Price { get; set; }
        public decimal PromotionPrice { get; set; }
        public int ViewCount { get; set; }
        public int Warranty { get; set; }
        public List<string> Catalogs { get; set; } = new List<string>();
    }
}
