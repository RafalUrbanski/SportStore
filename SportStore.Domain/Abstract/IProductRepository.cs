using System.Collections.Generic;
using SportStore.Domain.Entities;

namespace SportStore.Domain.Abstract
{
    public interface IProductRepository
    {
        #region Properties

        IEnumerable<Product> Products { get; }

        #endregion
    }
}
