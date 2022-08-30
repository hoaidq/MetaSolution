using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaSolution.Data.Entities
{
    public class ProductMedia
    {
        public int Id { get; set; }        
        public string? Title { get; set; }
        public int Type { get; set; }
        public string? Path { get; set; }
        public bool IsDefault { get; set; }
        public DateTime DateCreated { get; set; }
        public int SortOrder { get; set; }
        public long FileSize { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}