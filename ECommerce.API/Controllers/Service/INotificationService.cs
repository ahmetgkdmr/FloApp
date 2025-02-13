using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Services
{
    public interface INotificationService
    {
        Task<bool> SendNotificationAsync(int userId, string type, string message);
    }
}
