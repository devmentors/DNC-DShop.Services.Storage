using DShop.Services.Storage.Models.Customers;
using DShop.Services.Storage.Models.Products;
using System;
using System.Collections.Generic;

namespace DShop.Services.Storage.Models.Orders
{
    public class OrderDetails
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public long Number { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        public OrderStatus Status { get; set; }

        public enum OrderStatus : byte
        {
            Created = 0,
            Completed = 1,
            Canceled = 2,
        }
    }
}
