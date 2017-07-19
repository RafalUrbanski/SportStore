namespace SportStore.Domain.Entities
{
    public class Product
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        #endregion
    }
}
