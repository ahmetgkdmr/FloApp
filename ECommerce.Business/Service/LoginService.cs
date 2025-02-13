using ECommerce.Entity.Entities;
using ECommerce.Repository.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Business.Service
{
    public class LoginService : ILoginService
    {
        private readonly IRepository<User> _userRepository;

        public LoginService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> ValidateUserAsync(string username, string password)
        {

            var user = _userRepository.Find(u => u.UserName == username).FirstOrDefault();


            if (user == null || user.Password != password)
                return false;

            return true;
        }

        public string GenerateJwtToken(string username)
        {

            return $"token-for-{username}";
        }
    }
}
