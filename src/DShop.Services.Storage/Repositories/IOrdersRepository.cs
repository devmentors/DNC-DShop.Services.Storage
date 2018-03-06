using DShop.Common.Types;
using DShop.Services.Storage.Models.Orders;
using DShop.Services.Storage.Models.Queries;
using System;
using System.Threading.Tasks;

namespace DShop.Services.Storage.Repositories
{
    public interface IOrdersRepository
    {
        Task<Order> GetAsync(Guid id);
        Task<PagedResult<Order>> BrowseAsync(BrowseOrders query);
        Task CreateAsync(Order product);
        Task UpdateAsync(Order product);
    }
}
