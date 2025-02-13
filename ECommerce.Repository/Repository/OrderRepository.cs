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
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task UpdateAsync(Order entity)
        {
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<List<Order>> GetUserOrdersAsync(int userId)
        {
            return await _context.Orders
                                 .Where(o => o.UserId == userId)
                                 .ToListAsync();
        }


        public async Task<Order> GetOrderDetailsAsync(int orderId)
        {
            return await _context.Orders
                                 .Include(o => o.OrderItems)
                                 .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<Order> GetByIdAsync(int orderId)
        {
            return await _context.Orders
                                 .FirstOrDefaultAsync(o => o.Id == orderId);
        }
    }
}


