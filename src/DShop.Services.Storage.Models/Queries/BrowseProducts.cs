using DShop.Common.Types;

namespace DShop.Services.Storage.Models.Queries
{
    public class BrowseProducts : PagedQueryBase
    {
        public string Vendor { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }

        public BrowseProducts()
        {
            Vendor = string.Empty;
            PriceTo = decimal.MaxValue;
        }
    }
}