using System.Collections.Generic;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;

namespace SportStore.Domain.Repositories
{
    public class MockedProductRepository : IProductRepository
    {
        #region Fields

        private List<Product> products = new List<Product>
        {
            new Product
            {
                Name = "Rakieta",
                Description = "Podstawowy sprzet do tenisa",
                Price = 575,
                Category = "Tenis ziemny"
            },
            new Product
            {
                Name = "Piłka Tenisowa",
                Description = "Żółta zabawka dla Tosi",
                Price = 5,
                Category = "Tenis ziemny"
            },
            new Product
            {
                Name = "Termobag",
                Description = "Trzeba się jakoś nosić",
                Price = 250,
                Category = "Tenis ziemny"
            }
        };

        #endregion

        #region Properties

        public IEnumerable<Product> Products => products;

        #endregion
    }
}
