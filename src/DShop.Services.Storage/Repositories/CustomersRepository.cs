using DShop.Common.Mongo;
using DShop.Services.Storage.Models.Customers;
using MongoDB.Driver;

namespace DShop.Services.Storage.Repositories
{
    public class CustomersRepository : MongoRepository<Customer>, ICustomersRepository
    {
        protected CustomersRepository(IMongoDatabase database) : base(database, "Products")
        {
        }
    }
}