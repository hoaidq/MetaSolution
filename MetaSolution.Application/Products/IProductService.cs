
using MetaSolution.Data.Entities;
using MetaSolution.ViewModels.Common;
using MetaSolution.ViewModels.Products;

namespace MetaSolution.Application.Products
{
    public interface IProductService
    {
        Task<List<ProductVM>> GetAll();
        Task<PagedResult<ProductVM>> GetAllPaging(GetManageProductPagingRequest request);
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
    }
}
