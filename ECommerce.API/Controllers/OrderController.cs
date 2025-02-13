using ECommerce.Entity.DTOs;
using ECommerce.Entity.Entities;
using ECommerce.Business;
using ECommerce.Business.Service; // CartService için gerekli namespace
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService; // CartService ekleniyor

        public OrderController(IOrderService orderService, ICartService cartService)
        {
            _orderService = orderService;
            _cartService = cartService; // CartService'i enjekte ediyoruz
        }

        // Sipariş oluşturma
        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("Geçersiz sipariş verisi.");
            }

            int userId = 1; // Burada userId'yi statik belirliyoruz, gerçek uygulamada kimlik doğrulama kullanılabilir

            try
            {
                var createdOrder = await _orderService.CreateOrderAsync(userId, orderDto);
                return Ok(new { Message = "Sipariş başarıyla oluşturuldu.", Order = createdOrder });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir hata oluştu: {ex.Message}");
            }
        }

        // Sepetteki ürünleri sipariş olarak oluşturma (checkout)
        [HttpPost("order/checkout")]
        public async Task<IActionResult> Checkout(int userId)
        {
            try
            {
                var order = await _cartService.CreateOrderFromCartAsync(userId);
                return Ok(new { Message = "Sipariş başarıyla oluşturuldu.", Order = order });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
