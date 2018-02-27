using System;
using System.Threading.Tasks;
using DShop.Common.Mongo;
using DShop.Services.Storage.Models.Customers;

namespace DShop.Services.Storage.Repositories
{
    public interface ICustomersRepository
    {
        Task<Customer> GetAsync(Guid id);
        Task CreateAsync(Customer customer);
    }
}