using System.Threading.Tasks;
using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DShop.Messages.Events.Identity;

namespace DShop.Services.Storage.Handlers.Identity
{
    public class SignedUpHandler : IEventHandler<SignedUp>
    {
        public async Task HandleAsync(SignedUp @event, ICorrelationContext context)
        {
            await Task.CompletedTask;
        }
    }
}