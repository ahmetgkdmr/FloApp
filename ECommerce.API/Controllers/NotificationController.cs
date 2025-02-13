using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Business.Services;


namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendNotification([FromBody] NotificationRequest request)
        {
            var result = await _notificationService.SendNotificationAsync(request.UserId, request.Type, request.Message);

            if (result)
                return Ok("Bildirim başarıyla gönderildi.");
            return StatusCode(500, "Bildirim gönderilirken hata oluştu.");

        }

    }

    public class NotificationRequest
    {
        public int UserId { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
