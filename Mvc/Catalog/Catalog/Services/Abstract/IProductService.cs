using Catalog.Models;

namespace Catalog.Services.Abstract
{
    public interface IProductService
    {
        Task Add(Models.Catalog catalog, Product product, CancellationToken cancellationToken);

        Task Remove(Models.Catalog catalog, long productId, CancellationToken cancellationToken);
    }
}
