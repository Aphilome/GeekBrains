namespace Catalog.Models
{
    public class Category
    {
        private List<Product> _products { get; set; } = new();
        private object _writeLock = new object();

        public Category() { }

        public Category(int id, string name) 
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public void AddNewProduct(Product product)
        {
            lock(_writeLock)
            {
                _products.Add(product);
            }
        }

        public IReadOnlyCollection<Product> GetProducts()
        {
            return _products;
        }
    }
}
