using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ECommerce.Entity;
using ECommerce.Repository;
using System;
using System.Threading.Tasks;
using ECommerce.Repository.Repository;

namespace ECommerce.Business.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IRepository<Notification> _notificationRepository;

        public NotificationService(IRepository<Notification> notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<bool> SendNotificationAsync(int userId, string type, string message)
        {
            var notification = new Notification
            {
                UserId = userId,
                Type = type,
                Message = message,
                IsSent = false,
                SentDate = DateTime.Now
            };

            try
            {
                _notificationRepository.Add(notification);

                // Burada e-posta ya da SMS gönderim işlemi yapılabilir.
                // Örneğin, bir SMTP e-posta servisi kullanılabilir:
                Console.WriteLine($"[Bildirim Gönderildi] {type}: {message}");
                notification.IsSent = true;

                _notificationRepository.Update(notification);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Hata] Bildirim gönderilemedi: {ex.Message}");
                return false;
            }
        }
    }
}

