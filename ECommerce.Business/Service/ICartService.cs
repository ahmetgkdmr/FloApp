using ECommerce.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ECommerce.Entity.Entities;
using System.Threading.Tasks;

namespace ECommerce.Business
{
    public interface ICartService
    {
        Task<Cart> GetCartByUserIdAsync(int userId);
        Task AddToCartAsync(int userId, int productId, int quantity);
        Task RemoveFromCartAsync(int userId, int productId);
        Task<IEnumerable<CartItem>> GetCartItemsAsync(int cartId);
        Task ClearCartAsync(int userId);

        
        Task<Order> CreateOrderFromCartAsync(int userId);
    }
}

