using DShop.Services.Storage.Models.Orders;
using RestEase;
using System;
using System.Threading.Tasks;

namespace DShop.Services.Storage.ServiceForwarders
{
    public interface IOrdersService
    {
        [Get("/orders/{id}")]
        Task<Order> GetByIdAsync([Path] Guid id);
    }
}
