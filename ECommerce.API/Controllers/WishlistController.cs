using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Business;
using ECommerce.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly WishlistService _wishlistService;

        public WishlistController(WishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }


        [HttpPost]
        public IActionResult AddToWishlist(int userId, int productId)
        {
            _wishlistService.AddToWishlist(userId, productId);
            return Ok("Product added to wishlist");
        }

        [HttpDelete]
        public IActionResult RemoveFromWishlist(int userId, int productId)
        {
            _wishlistService.RemoveFromWishlist(userId, productId);
            return Ok("Product removed from wishlist");
        }

        
        [HttpGet("{userId}")]
        public IActionResult GetWishlist(int userId)
        {
            var wishlist = _wishlistService.GetWishlistByUserId(userId);
            return Ok(wishlist);
        }
    }   
}

