using ECommerce.Entity.Entities;
using ECommerce.Repository.Repository;

namespace ECommerce.Business.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public List<User> GetAll() => _repository.GetAll().ToList();

        public User GetById(int id) => _repository.GetById(id);

        public void Add(User user) => _repository.Add(user);

        public void Update(User user) => _repository.Update(user);

        public void Delete(int id)
        {
            var user = _repository.GetById(id);
            if (user != null)
                _repository.Delete(user);
        }

        User IUserService.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
