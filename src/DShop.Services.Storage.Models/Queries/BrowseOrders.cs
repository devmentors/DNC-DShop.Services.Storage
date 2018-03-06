using DShop.Common.Types;
using System;

namespace DShop.Services.Storage.Models.Queries
{
    public class BrowseOrders : PagedQueryBase
    {
        public Guid CustomerId { get; set; }
    }
}
