using DShop.Common.Mongo;
using DShop.Services.Storage.Models.Products;

namespace DShop.Services.Storage.Repositories
{
    public interface IProductsRepository : IMongoRepository<Product>
    {
    }
}
