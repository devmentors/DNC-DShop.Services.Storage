using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DShop.Messages.Events.Products;
using System;
using System.Threading.Tasks;

namespace DShop.Services.Storage.Handlers.Products
{
    public sealed class ProductUpdatedHandler : IEventHandler<ProductUpdated>
    {
        public async Task HandleAsync(ProductUpdated @event, ICorrelationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
