using BasketSpa.API.Models;
using BasketSpa.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BasketSpa.API.Controllers
{
    [ApiController]
    [Route("ape/v1/[controller]")]
    public class BasketSpaController:ControllerBase
    {
        private readonly IBasketRepository basketRepository;
        public BasketSpaController(IBasketRepository basketRepository) 
        { 
            this.basketRepository = basketRepository;
        }

        [HttpGet]
        [Route("[action]/{userName}")]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            var basket = await basketRepository.GetBasket(userName);
            return Ok(basket ?? new ShoppingCart(userName));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket(ShoppingCart shoppingCart)
        {
            return Ok(await basketRepository.UpdateBasket(shoppingCart));
        }

        [HttpDelete]
        [Route("[action]/{userName}")]
        public async Task<ActionResult> DeleteBasket(string userName)
        {
            await basketRepository.DeleteBasket(userName);
            return Ok();
        }
    }
}
