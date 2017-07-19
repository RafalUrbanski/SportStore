using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportStore.Domain.Abstract;

namespace SportsStore.Web.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository productRepository;

        public NavController(IProductRepository productRepositoryParam)
        {
            productRepository = productRepositoryParam;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            var categories = productRepository.Products
                .Select(prod => prod.Category)
                .Distinct()
                .OrderBy(cat => cat);

            return PartialView(categories);
        }
    }
}