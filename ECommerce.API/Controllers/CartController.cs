using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Business.Service;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart(int userId, int productId, int quantity)
        {
            await _cartService.AddToCartAsync(userId, productId, quantity);
            return Ok("Product added to cart");
        }

        [HttpGet("items")]
        public async Task<IActionResult> GetCartItems(int userId)
        {
            var items = await _cartService.GetCartItemsAsync(userId);
            return Ok(items);
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveFromCart(int userId, int productId)
        {
            await _cartService.RemoveFromCartAsync(userId, productId);
            return Ok("Product removed from cart");
        }

        [HttpDelete("clear")]
        public async Task<IActionResult> ClearCart(int userId)
        {
            await _cartService.ClearCartAsync(userId);
            return Ok("Cart cleared");
        }
    }
}

