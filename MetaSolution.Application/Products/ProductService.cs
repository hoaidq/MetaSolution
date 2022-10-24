using MetaSolution.Data.EF;
using MetaSolution.Data.Entities;
using MetaSolution.Utilities;
using MetaSolution.Utilities.Constants;
using MetaSolution.Utilities.Exceptions;
using MetaSolution.ViewModels.Common;
using MetaSolution.ViewModels.Products;
using Microsoft.EntityFrameworkCore;

namespace MetaSolution.Application.Products
{
    public class ProductService : IProductService
    {
        private readonly MetaDbContext _context;

        public ProductService(MetaDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductVM>> GetAll()
        {
            var query = from p in _context.Products
                        join pl in _context.ProductLanguages on p.Id equals pl.ProductId
                        join pic in _context.ProductInCatalogs on p.Id equals pic.ProductId
                        join c in _context.Catalogs on pic.CatalogId equals c.Id
                        select new { p, pl, pic, c };

            var data = await query.Select(x => new ProductVM()
            {
                Id = x.p.Id,
                Title = x.pl.Title,
                Description = x.pl.Description,
                Content = x.pl.Content
            }).ToListAsync();

            return data;
        }

        public async Task<PagedResult<ProductVM>> GetAllPaging(GetManageProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pl in _context.ProductLanguages on p.Id equals pl.ProductId
                        join pic in _context.ProductInCatalogs on p.Id equals pic.ProductId
                        join c in _context.Catalogs on pic.CatalogId equals c.Id
                        select new { p, pl, pic, c };

            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pl.Title.Contains(request.Keyword));

            if (request.CatalogId != null && request.CatalogId != 0)
            {
                query = query.Where(x => x.pic.CatalogId == request.CatalogId);
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).Select(x => new ProductVM()
            {
                Id = x.p.Id,
                Title = x.pl.Title,
                Description = x.pl.Description,
                Content = x.pl.Content
            }).ToListAsync();

            var pagedResult = new PagedResult<ProductVM>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };

            return pagedResult;
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var languages = _context.Languages;
            var translations = new List<ProductLanguage>();

            foreach (var language in languages)
            {
                if (language.Code == request.LanguageCode)
                {
                    translations.Add(new ProductLanguage()
                    {
                        Title = request.Title,
                        Description = request.Description,
                        Content = request.Content,
                        TitleSite = request.TitleSite,
                        MetaKeywords = request.MetaKeywords,
                        MetaDescription = request.MetaDescription,
                        LanguageCode = request.LanguageCode
                    });
                }
                else
                {
                    translations.Add(new ProductLanguage()
                    {
                        Title = SystemConstants.ProductConstants.NA,
                        Description = SystemConstants.ProductConstants.NA,
                        Content = SystemConstants.ProductConstants.NA,
                        TitleSite = SystemConstants.ProductConstants.NA,
                        MetaKeywords = SystemConstants.ProductConstants.NA,
                        MetaDescription = SystemConstants.ProductConstants.NA,
                        LanguageCode = language.Code
                    });
                }
            }

            var product = new Product()
            {
                Price = request.Price,
                PromotionPrice = request.PromotionPrice,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductLanguages = translations
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product.Id;
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productLanguages = await _context.ProductLanguages.FirstOrDefaultAsync(x => x.ProductId == request.Id && x.LanguageCode == request.LanguageCode);

            if (product == null || productLanguages == null) throw new MetaException($"Cannot find a product with id: {request.Id}");

            productLanguages.Title = request.Title;
            productLanguages.Description = request.Description;
            productLanguages.Content = request.Content;

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new MetaException($"Cannot find a product: {productId}");

            _context.Products.Remove(product);

            return await _context.SaveChangesAsync();
        }
    }
}
