using System.Collections.Concurrent;

namespace Catalog.Models
{
    public class Catalog
    {
        private ConcurrentBag<Category> _categories { get; }

        public Catalog()
        {
            var vegetablesCategory = new Models.Category(1, "Vegetables");
            vegetablesCategory.AddNewProduct(new Product(1, vegetablesCategory.Id, "Potetor"));
            vegetablesCategory.AddNewProduct(new Product(2, vegetablesCategory.Id, "Tomato"));
            
            var fruitsCategory = new Models.Category(2, "Fruits");
            fruitsCategory.AddNewProduct(new Product(1, fruitsCategory.Id, "Apple"));
            fruitsCategory.AddNewProduct(new Product(2, fruitsCategory.Id, "Orange"));

            _categories = new ConcurrentBag<Category>
            {
                vegetablesCategory,
                fruitsCategory
            };
        }

        public void AddCategory(Category newCategory)
        {
            _categories.Add(newCategory);
        }

        public IReadOnlyCollection<Category> GetCategories()
        {
            return _categories;
        }
    }
}
