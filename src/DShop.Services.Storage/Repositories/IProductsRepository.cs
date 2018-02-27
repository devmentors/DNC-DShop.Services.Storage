using System;
using System.Threading.Tasks;
using DShop.Common.Mongo;
using DShop.Services.Storage.Models.Products;

namespace DShop.Services.Storage.Repositories
{
    public interface IProductsRepository
    {
        Task<Product> GetAsync(Guid id);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid id);
    }
}
