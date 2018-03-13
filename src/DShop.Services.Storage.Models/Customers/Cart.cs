using System.Collections.Generic;
using System.Linq;

namespace DShop.Services.Storage.Models.Customers
{
    public class Cart
    {
        public IList<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal TotalPrice => Items.Sum(x => x.TotalPrice);
    }
}