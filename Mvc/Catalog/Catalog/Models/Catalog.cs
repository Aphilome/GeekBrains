using System.Collections.Concurrent;

namespace Catalog.Models
{
    public class Catalog
    {
        private ConcurrentDictionary<int, Category> _categories { get; }

        public Catalog()
        {
            var vegetablesCategory = new Category(1, "Vegetables");
            vegetablesCategory.AddNewProduct(new Product(1, vegetablesCategory.Id, "Potetor"));
            vegetablesCategory.AddNewProduct(new Product(2, vegetablesCategory.Id, "Tomato"));
            
            var fruitsCategory = new Category(2, "Fruits");
            fruitsCategory.AddNewProduct(new Product(1, fruitsCategory.Id, "Apple"));
            fruitsCategory.AddNewProduct(new Product(2, fruitsCategory.Id, "Orange"));

            _categories = new ConcurrentDictionary<int, Category>();
            _categories[vegetablesCategory.Id] = vegetablesCategory;
            _categories[fruitsCategory.Id] = fruitsCategory;
        }

        public void AddCategory(Category newCategory)
        {
            _categories[newCategory.Id] = newCategory;
        }

        public IReadOnlyCollection<Category> GetCategories()
        {
            return _categories.Values.ToArray();
        }

        public void RemoveCategory(Category removeCategory)
        {
            _categories.Remove(removeCategory.Id, out _);
        }
    }
}
