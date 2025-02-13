using ECommerce.Entity.Entities;
using ECommerce.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Service
{
    public class UserTypeService : IUserTypeService
    {
        private readonly IRepository<UserType> _repository;

        public UserTypeService(IRepository<UserType> repository)
        {
            _repository = repository;
        }

        public List<UserType> GetAll() => _repository.GetAll().ToList();

        public UserType GetById(int id) => _repository.GetById(id);

        public void Add(UserType UserType) => _repository.Add(UserType);

        public void Update(UserType UserType) => _repository.Update(UserType);

        public void Delete(int id)
        {
            var UserType = _repository.GetById(id);
            if (UserType != null)
                _repository.Delete(UserType);
        }

        List<User> IUserTypeService.GetAll()
        {
            throw new NotImplementedException();
        }

        User IUserTypeService.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}