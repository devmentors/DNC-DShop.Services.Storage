using DShop.Messages.Entities;
using System;

namespace DShop.Services.Storage.Models.Products
{
    public class Product : IIdentifiable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Vendor { get; set; }
        public decimal Price { get; set; }        
    }
}