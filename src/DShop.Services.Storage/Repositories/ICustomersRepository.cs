using System;
using System.Threading.Tasks;
using DShop.Common.Mongo;
using DShop.Common.Types;
using DShop.Services.Storage.Models.Customers;
using DShop.Services.Storage.Models.Queries;

namespace DShop.Services.Storage.Repositories
{
    public interface ICustomersRepository
    {
        Task<Customer> GetAsync(Guid id);
        Task<PagedResult<Customer>> BrowseAsync(BrowseCustomers query);
        Task CreateAsync(Customer customer);
    }
}