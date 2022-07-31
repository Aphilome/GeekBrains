using System.Collections.Concurrent;

namespace Catalog.Models
{
    public class Category
    {
        private ConcurrentDictionary<long, Product> _products { get; set; } = new();

        public Category() { }

        public Category(long id, string name) 
        {
            Id = id;
            Name = name;
        }

        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public void AddNewProduct(Product product)
        {
            _products[product.Id] = product;
        }

        public IReadOnlyCollection<Product> GetProducts()
        {
            return _products.Values.ToArray();
        }

        public void RemoveProduct(Product product)
        {
            _products.TryRemove(product.Id, out _);
        }

        public void RemoveProduct(long productId)
        {
            _products.TryRemove(productId, out _);
        }
    }
}
