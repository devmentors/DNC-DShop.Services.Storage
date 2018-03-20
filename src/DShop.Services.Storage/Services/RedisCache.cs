using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace DShop.Services.Storage.Services
{
    public class RedisCache : ICache
    {
        private readonly IDistributedCache _cache;

        public RedisCache(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var value = await _cache.GetStringAsync(key);

            return string.IsNullOrWhiteSpace(value) ? default(T) : 
                JsonConvert.DeserializeObject<T>(await _cache.GetStringAsync(key));
        }

        public async Task SetAsync<T>(string key, T value)
            => await _cache.SetStringAsync(key, JsonConvert.SerializeObject(value));
    }
}