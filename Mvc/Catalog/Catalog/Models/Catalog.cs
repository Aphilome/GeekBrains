namespace Catalog.Models
{
    public class Catalog
    {
        private List<Category> _categories { get; } 
        private object _writeLock;

        public Catalog()
        {
            _writeLock = new object();
            var vegetablesCategory = new Models.Category(1, "Vegetables");
            vegetablesCategory.AddNewProduct(new Product(1, vegetablesCategory.Id, "Potetor"));
            vegetablesCategory.AddNewProduct(new Product(2, vegetablesCategory.Id, "Tomato"));
            
            var fruitsCategory = new Models.Category(2, "Fruits");
            fruitsCategory.AddNewProduct(new Product(1, fruitsCategory.Id, "Apple"));
            fruitsCategory.AddNewProduct(new Product(2, fruitsCategory.Id, "Orange"));

            _categories = new List<Category>
            {
                vegetablesCategory,
                fruitsCategory
            };
        }

        public void AddCategory(Category newCategory)
        {
            lock (_writeLock)
            {
                _categories.Add(newCategory);
            }
        }

        public IReadOnlyCollection<Category> GetCategories()
        {
            return _categories;
        }
    }
}
