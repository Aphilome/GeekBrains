using CardStorageServiceData;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardStorageService.Services.Impl
{
    public class CardRepository : ICardRepositoryService
    {

        #region Services

        private readonly CardStorageServiceDbContext _context;
        private readonly ILogger<CardRepository> _logger;

        #endregion

        public CardRepository(
            ILogger<CardRepository> logger,
            IOptions<DatabaseOptions> databaseOptions,
            CardStorageServiceDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public string Create(Card data)
        {
            var client = _context.Clients.FirstOrDefault(client => client.ClientId == data.ClientId);
            if (client == null)
                throw new Exception("Client not founds");

            _context.Cards.Add(data);

            _context.SaveChanges();

            return data.CardId.ToString();
        }

        public IList<Card> GetByClientId(int id)
        {
            return _context.Cards.Where(card => card.ClientId == id).ToList();
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
