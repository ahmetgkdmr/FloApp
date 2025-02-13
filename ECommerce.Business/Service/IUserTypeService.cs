using ECommerce.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Service
{
    public interface IUserTypeService
    {
        List<User> GetAll();
        User GetById(int id);
        void Add(UserType userType);
        void Update(UserType userType);
        void Delete(int id);

    }
}
