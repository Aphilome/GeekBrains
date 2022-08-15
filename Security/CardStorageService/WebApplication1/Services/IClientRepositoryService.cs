using CardStorageService.Services.Impl;
using CardStorageServiceData;

namespace CardStorageService.Services
{
    public interface IClientRepositoryService : IRepository<Client, int>
    {
    }
}
