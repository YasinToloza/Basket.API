using BasketSpa.API.Models;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace BasketSpa.API.Repositories
{
    public class basketRepository : IBasketRepository
    {
        private readonly IDistributedCache redis;
        public basketRepository(IDistributedCache redis) 
        {
            this.redis = redis;
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await redis.GetStringAsync(userName);
            if (String.IsNullOrEmpty(userName))
                return null;
            return JsonSerializer.Deserialize<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart)
        {
            await redis.SetStringAsync(shoppingCart.UserName, JsonSerializer.Serialize(shoppingCart));
            return await GetBasket(shoppingCart.UserName);
        }

        public async Task DeleteBasket(string userName)
        {
            await redis.RemoveAsync(userName);
        }
    }
}
