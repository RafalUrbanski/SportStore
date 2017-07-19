using System.Collections.Generic;
using SportStore.Domain.Entities;

namespace SportsStore.Web.Models
{
    public class ProductsListViewModel
    {
        #region Properties

        public IEnumerable<Product> Products { get; set; }
        public string CurrentCategory { get; set; }
        public PagingInfo PagingInfo { get; set; }

        #endregion
    }
}
