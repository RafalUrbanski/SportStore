using System.Linq;
using System.Web.Mvc;
using SportsStore.Web.Models;
using SportStore.Domain.Abstract;

namespace SportsStore.Web.Controllers
{
    public class ProductController : Controller
    {
        #region Fields

        private IProductRepository productRepository;
        public int PageSize = 2;

        #endregion

        #region Constructors

        public ProductController(IProductRepository productRepositoryParam)
        {
            productRepository = productRepositoryParam;
        }

        #endregion

        #region Public Methods

        public ViewResult List(string category, int page = 1)
        {
            return View(new ProductsListViewModel
            {
                Products = productRepository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                CurrentCategory = category,
                PagingInfo = new PagingInfo
                {
                    TotalItems = productRepository.Products.Count(p => category == null || p.Category == category),
                    ItemsPerPage = PageSize,
                    CurrentPage = page
                }
            });
        }

        #endregion
    }
}