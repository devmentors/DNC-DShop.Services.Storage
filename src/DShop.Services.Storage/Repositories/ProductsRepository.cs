using DShop.Common.Mongo;
using DShop.Common.Types;
using DShop.Services.Storage.Models.Products;
using DShop.Services.Storage.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DShop.Services.Storage.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IMongoRepository<Product> _repository;

        public ProductsRepository(IMongoRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Product> GetAsync(Guid id)
            => await _repository.GetAsync(id);

        public async Task<IEnumerable<Product>> FindAsync(Expression<Func<Product, bool>> predicate)
            => await _repository.FindAsync(predicate);

        public async Task<PagedResult<Product>> BrowseAsync(BrowseProducts query)
            => await _repository.BrowseAsync(p =>
                p.Price >= query.PriceFrom && p.Price <= query.PriceTo, query);

        public async Task CreateAsync(Product product)
            => await _repository.CreateAsync(product);

        public async Task UpdateAsync(Product product)
            => await _repository.UpdateAsync(product);

        public async Task DeleteAsync(Guid id)
            => await _repository.DeleteAsync(id);
    }
}
