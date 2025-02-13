using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Entity.Entities;

namespace ECommerce.Business
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(int userId, Entity.DTOs.OrderDto orderDto); 
        Task UpdateOrderStatusAsync(int orderId, string status); 
        Task<List<Order>> GetUserOrdersAsync(int userId); 
        Task<Order> GetOrderDetailsAsync(int orderId);
        Task GetOrdersByUserIdAsync(int userId);
        void CreateOrder(Order order);
    }
}

