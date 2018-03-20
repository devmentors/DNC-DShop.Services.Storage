using System;
using System.Threading.Tasks;
using DShop.Services.Storage.Models.Customers;
using DShop.Services.Storage.Services;

namespace DShop.Services.Storage.Framework
{
    public static class Extensions
    {
        public static async Task<Cart> GetCartAsync(this ICache cache, Guid userId)
            => await cache.GetAsync<Cart>(GetCartKey(userId));

        public static async Task SetCartAsync(this ICache cache, Guid userId, Cart cart)
            => await cache.SetAsync(GetCartKey(userId), cart);

        public static async Task ClearCartAsync(this ICache cache, Guid userId)
        {
            var cart = await cache.GetCartAsync(userId);
            cart.Items.Clear();
            await cache.SetCartAsync(userId, cart);            
        }

        private static string GetCartKey(Guid userId)
            => GetKey(userId, "cart");

        private static string GetKey(Guid userId, string type)
            => $"users:{userId}:{type}".ToLowerInvariant();
    }
}