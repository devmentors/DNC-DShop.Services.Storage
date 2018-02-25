using DShop.Common.Mongo;
using DShop.Services.Storage.Models.Customers;

namespace DShop.Services.Storage.Repositories
{
    public interface ICustomersRepository : IMongoRepository<Customer>
    {
    }
}