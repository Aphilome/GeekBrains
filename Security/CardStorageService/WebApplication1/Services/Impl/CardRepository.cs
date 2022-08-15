using CardStorageServiceData;
using Microsoft.Extensions.Logging;

namespace CardStorageService.Services.Impl
{
    public class CardRepository : ICardRepositoryService
    {
        #region Services

        private readonly CardStorageServiceDbContext _context;
        private readonly ILogger<CardRepository> _logger;
        //private readonly IOptions<DatabaseOptions> _databaseOptions;

        #endregion

        public CardRepository(
            ILogger<CardRepository> logger,
            //IOptions<DatabaseOptions> databaseOptions,
            CardStorageServiceDbContext context)
        {
            _logger = logger;
            //_databaseOptions = databaseOptions;
            _context = context;
        }
        public string Create(Card data)
        {
            throw new System.NotImplementedException();
        }

        public int Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public IList<Card> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Card GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public int Update(Card data)
        {
            throw new System.NotImplementedException();
        }
    }
}
