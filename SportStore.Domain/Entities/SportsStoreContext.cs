using System.Data.Entity;
using SportStore.Domain.Entities.Configurations;

namespace SportStore.Domain.Entities
{
    class SportsStoreContext : DbContext
    {
        #region Properties

        public DbSet<Product> Products { get; set; }

        #endregion

        #region Constructors

        public SportsStoreContext(): base("SportsStoreContext")
        {

        }

        #endregion

        #region Non-public Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ProductsConfiguration());
        }

        #endregion
    }
}
