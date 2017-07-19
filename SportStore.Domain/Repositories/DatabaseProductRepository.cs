using System.Collections.Generic;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;

namespace SportStore.Domain.Repositories
{
    public class DatabaseProductRepository : IProductRepository
    {
        #region Fields

        private SportsStoreContext context = new SportsStoreContext();

        #endregion

        #region Properties

        public IEnumerable<Product> Products => context.Products;

        #endregion
    }
}
