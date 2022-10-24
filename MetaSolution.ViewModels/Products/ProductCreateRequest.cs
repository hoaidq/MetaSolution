using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaSolution.ViewModels.Products
{
    public class ProductCreateRequest
    {
        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm!")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string TitleSite { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public decimal Price { get; set; }
        public decimal PromotionPrice { get; set; }
        public string LanguageCode { get; set; }
    }
}
