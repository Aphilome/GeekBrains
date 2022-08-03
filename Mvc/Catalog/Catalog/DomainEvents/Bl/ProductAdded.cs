using Catalog.Models;

namespace Catalog.DomainEvents.Bl
{
    public class ProductAdded : IDomainEvent
    {
        public Product NewProduct { get; set; }
    }
}
