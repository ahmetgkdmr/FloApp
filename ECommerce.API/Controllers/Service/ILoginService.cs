using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Service
{
    public interface ILoginService
    {
        Task<bool> ValidateUserAsync(string username, string password);
        string GenerateJwtToken(string username);
    }
}
