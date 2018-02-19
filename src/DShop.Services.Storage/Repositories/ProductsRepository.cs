using DShop.Common.Mongo;
using DShop.Services.Storage.Models.Products;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DShop.Services.Storage.Repositories
{
    public class ProductsRepository : MongoRepository<Product>, IProductsRepository
    {
        public ProductsRepository(IMongoDatabase database) : base(database, "Products")
        {
        }
    }
}
