using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Entities;
using Timesheets.Services.Abstracts;
using Timesheets.Services.Concrete;
using Xunit;

namespace XUnitTester
{
    public class ClientServiceTest
    {
        [Fact]
        public void ClientService_CreateTest()
        {
            var collection = new List<BaseEntity>();
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(i => i.AddAsync(It.IsAny<BaseEntity>())).Returns((BaseEntity i) =>
            { 
                collection.Add(i);
                return Task.CompletedTask;
            });

            var service = new ClientService(repositoryMock.Object);
            var _ = service.CreateAsync().Result;

            Assert.Single(collection);
        }

        [Fact]
        public void ClientService_GetAll()
        {
            IReadOnlyCollection<Client> collection = new List<Client>()
            {
                new Client(),
                new Client(),
                new Client(),
            };
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(i => i.GetAllAsync<Client>()).Returns(() =>
            { 
                return Task.FromResult(collection);
            });

            var service = new ClientService(repositoryMock.Object);
            var result = service.GetAllAsync().Result;

            Assert.Equal(3, result.Count);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ClientService_Get(long id)
        {
            IReadOnlyCollection<Client> collection = new List<Client>()
            {
                new Client() { Id = 1 },
                new Client() { Id = 2 },
                new Client() { Id = 3 },
            };
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(i => i.GetAsync<Client>(It.IsAny<long>())).Returns((long id) =>
            { 
                return Task.FromResult(collection.FirstOrDefault(i => i.Id == id));
            });

            var service = new ClientService(repositoryMock.Object);
            var result = service.GetAsync(id).Result;

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        public void ClientService_Remove(long id)
        {
            var collection = new List<Client>()
            {
                new Client() { Id = 1 },
                new Client() { Id = 2 },
                new Client() { Id = 3 },
            };
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(i => i.RemoveAsync<Client>(It.IsAny<long>())).Returns((long id) =>
            { 
                var f = collection.FirstOrDefault(i => i.Id == id);
                if (f != null)
                    collection.Remove(f);
                return Task.CompletedTask;
            });

            var service = new ClientService(repositoryMock.Object);
            service.RemoveAsync(id).Wait();

            Assert.Null(collection.FirstOrDefault(i => i.Id == id));
        }

        [Fact]
        public void ClientService_Update()
        {
            var collection = new List<Client>()
            {
                new Client() { Id = 1 },
                new Client() { Id = 2, Name = "abc" },
                new Client() { Id = 3 },
            };
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(i => i.UpdateAsync<Client>(It.IsAny<long>(), It.IsAny<Client>())).Returns((long id, Client client) =>
            { 
                var f = collection.FirstOrDefault(i => i.Id == id);
                if (f != null)
                    f.Name = client.Name;
                return Task.CompletedTask;
            });

            var service = new ClientService(repositoryMock.Object);
            service.UpdateAsync(2, new Client { Name = "cde" }).Wait();

            Assert.Equal("cde", collection[1].Name);
        }
    }
}