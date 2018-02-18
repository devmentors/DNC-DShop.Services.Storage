using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DShop.Messages.Events.Products;
using System;
using System.Threading.Tasks;

namespace DShop.Services.Storage.Handlers.Products
{
    public sealed class ProductCreatedHandler : IEventHandler<ProductCreated>
    {
        public async Task HandleAsync(ProductCreated @event, ICorrelationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
