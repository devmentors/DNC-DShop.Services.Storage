using System;
using System.Threading.Tasks;
using DShop.Services.Storage.Models.Customers;
using RestEase;

namespace DShop.Services.Storage.ServiceForwarders
{
    public interface ICustomersService
    {
        [Get("/customers/{id}")]
        Task<Customer> GetByIdAsync([Path] Guid id);
    }
}