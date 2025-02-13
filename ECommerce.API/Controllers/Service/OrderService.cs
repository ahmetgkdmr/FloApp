using ECommerce.Entity.DTOs;
using ECommerce.Entity.Entities;
using ECommerce.Repository.Repository;

namespace ECommerce.Business
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;

        public OrderService(IOrderRepository orderRepository, ICartRepository cartRepository)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
        }

        // Belirli bir siparişi al
        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            return order;
        }

        
        public async Task<Order> CreateOrderAsync(int userId, OrderDto orderDto)
        {
            if (orderDto == null || orderDto.Items == null || !orderDto.Items.Any())
                throw new Exception("Sipariş verisi geçersiz ya da ürünler eksik.");

            var totalAmount = orderDto.Items.Sum(item => item.Quantity * item.Price);

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                TotalAmount = totalAmount,
                Status = "Beklemede", 
                OrderItems = orderDto.Items.Select(item => new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList()
            };

            await _orderRepository.AddAsync(order);
            return order;
        }

        
        public async Task UpdateOrderStatusAsync(int orderId, string status)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);

            if (order == null)
                throw new Exception("Sipariş bulunamadı.");

            order.Status = status;
            await _orderRepository.UpdateAsync(order);
        }

        // Kullanıcının tüm siparişlerini al
        public async Task<List<Order>> GetUserOrdersAsync(int userId)
        {
            return await _orderRepository.GetUserOrdersAsync(userId);
        }

        // Belirli bir siparişin detaylarını al
        public async Task<Order> GetOrderDetailsAsync(int orderId)
        {
            return await _orderRepository.GetOrderDetailsAsync(orderId);
        }

        public Task<Order> CreateOrderAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task GetOrdersByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public void CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
