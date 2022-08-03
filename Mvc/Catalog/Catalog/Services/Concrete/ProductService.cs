using Catalog.DomainEvents;
using Catalog.DomainEvents.Bl;
using Catalog.Models;
using Catalog.Services.Abstract;

namespace Catalog.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IMailSender _mailSender;

        public ProductService(
            IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public async Task Add(Models.Catalog catalog, Product product, CancellationToken cancellationToken)
        {
            catalog.GetCategories().First(i => i.Id == product.CategoryId).AddNewProduct(product);
            DomainEventsManager.Raise(new ProductAdded()
            {
                NewProduct = product
            });
        }

        public async Task Remove(Models.Catalog catalog, long productId, CancellationToken cancellationToken)
        {
            foreach (var category in catalog.GetCategories())
                category.RemoveProduct(productId);
        }
    }
}
