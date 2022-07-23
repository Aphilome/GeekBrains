namespace Catalog.Models
{
    public class Product
    {
        public Product() { }

        public Product(long id, long categoryId, string name)
        {
            Id = id;
            CategoryId = categoryId;
            Name = name;
        }

        public long Id { get; set; }

        public long CategoryId { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
