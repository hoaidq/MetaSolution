using MetaSolution.ViewModels.Common;

namespace MetaSolution.ViewModels.Products
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public string LanguageCode { get; set; }

        public int? CatalogId { get; set; }
    }
}
