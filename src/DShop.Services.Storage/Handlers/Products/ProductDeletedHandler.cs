using DShop.Common.Bus;
using DShop.Common.Handlers;
using DShop.Messages.Events.Products;
using System;
using System.Threading.Tasks;

namespace DShop.Services.Storage.Handlers.Products
{
    public sealed class ProductDeletedHandler : IEventHandler<ProductDeleted>
    {
        public async Task HandleAsync(ProductDeleted @event, ICorrelationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
