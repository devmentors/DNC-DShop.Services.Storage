using DShop.Services.Storage.Models.Customers;
using DShop.Services.Storage.Models.Products;
using System.Collections.Generic;

namespace DShop.Services.Storage.Models.Orders
{
    public class OrderDetails
    {
        public Order Order { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
