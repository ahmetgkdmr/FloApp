using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ECommerce.Entity.Entities;

namespace ECommerce.Repository.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetUserOrdersAsync(int userId);
        Task<Order> GetOrderDetailsAsync(int orderId);
        Task<Order> GetByIdAsync(int orderId);

        Task UpdateAsync(Order entity);
    }
}

