using System.Collections.Concurrent;

namespace Catalog.Models
{
    public class Category
    {
        private ConcurrentBag<Product> _products { get; set; } = new();

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
            _products.Add(product);
        }

        public IReadOnlyCollection<Product> GetProducts()
        {
            return _products;
        }
    }
}
