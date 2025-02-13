using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Data;
using ECommerce.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repository.Repository
{
    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        // Kullanıcıya ait sepeti al
        public async Task<Cart> GetCartAsync(int userId)
        {
            return await _context.Carts
                           .Include(c => c.CartItems)
                           .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        // Kullanıcıya ait sepet öğelerini al
        public async Task<List<CartItem>> GetCartItemsAsync(int userId)
        {
            return await _context.CartItems
                                 .Where(ci => ci.Cart.UserId == userId)
                                 .ToListAsync();
        }

        public async Task UpdateAsync(Cart cart)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
        }
        public async Task<Cart> GetByIdAsync(int id)
        {
            return await _context.Carts
                                 .Include(c => c.CartItems)
                                 .FirstOrDefaultAsync(c => c.Id == id);
        }
    }

}
