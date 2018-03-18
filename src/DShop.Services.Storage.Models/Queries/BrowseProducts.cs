using DShop.Common.Types;

namespace DShop.Services.Storage.Models.Queries
{
    public class BrowseProducts : PagedQueryBase
    {
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }

        public BrowseProducts()
        {
            PriceTo = decimal.MaxValue;
        }
    }
}