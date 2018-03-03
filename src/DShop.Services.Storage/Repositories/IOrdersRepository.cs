using DShop.Services.Storage.Models.Orders;
using System;
using System.Threading.Tasks;

namespace DShop.Services.Storage.Repositories
{
    public interface IOrdersRepository
    {
        Task<Order> GetAsync(Guid id);
        Task CreateAsync(Order product);
        Task UpdateAsync(Order product);
    }
}
