using CardStorageService.Services.Impl;
using CardStorageServiceData;

namespace CardStorageService.Services
{
    public interface ICardRepositoryService : IRepository<Card, string>
    {
    }
}
