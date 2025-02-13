using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ECommerce.Entity.Entities;

namespace ECommerce.Repository.Repository
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<List<CartItem>> GetCartItemsAsync(int userId);
        Task<Cart> GetCartAsync(int userId);

        Task UpdateAsync(Cart cart);
        Task<Cart> GetByIdAsync(int id);
    }
}

