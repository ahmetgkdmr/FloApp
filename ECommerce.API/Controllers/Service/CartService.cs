using ECommerce.Entity.DTOs;
using ECommerce.Entity.Entities;
using ECommerce.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository; 

        public CartService(ICartRepository cartRepository, IOrderRepository orderRepository)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository; 
        }

        public async Task<Cart> GetCartByUserIdAsync(int userId)
        {
            var cart = await _cartRepository
                            .Find(c => c.UserId == userId)
                            .FirstOrDefaultAsync();
            return cart;
        }

        public async Task AddToCartAsync(int userId, int productId, int quantity)
        {
            var cart = await GetCartByUserIdAsync(userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId, CartItems = new List<CartItem>() };
                await _cartRepository.AddAsync(cart);
            }

            var cartItem = new CartItem
            {
                CartId = cart.Id,
                ProductId = productId,
                Quantity = quantity
            };

            cart.CartItems.Add(cartItem);
            await _cartRepository.UpdateAsync(cart);
        }

        public async Task RemoveFromCartAsync(int userId, int productId)
        {
            var cart = await GetCartByUserIdAsync(userId);

            if (cart != null)
            {
                var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
                if (cartItem != null)
                {
                    cart.CartItems.Remove(cartItem);
                    await _cartRepository.UpdateAsync(cart);
                }
            }
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsAsync(int cartId)
        {
            var cart = await _cartRepository.GetByIdAsync(cartId);
            return cart?.CartItems.Select(ci => new CartItem
            {
                ProductId = ci.ProductId,
                Quantity = ci.Quantity,
                Price = ci.Price
            }) ?? Enumerable.Empty<CartItem>();
        }

        public async Task ClearCartAsync(int userId)
        {
            var cart = await GetCartByUserIdAsync(userId);

            if (cart != null)
            {
                cart.CartItems.Clear();
                await _cartRepository.UpdateAsync(cart);
            }
        }

        // Sepetteki ürünleri sipariş olarak oluşturma (checkout)
        public async Task<Order> CreateOrderFromCartAsync(int userId)
        {
            var cart = await GetCartByUserIdAsync(userId);

            if (cart == null || !cart.CartItems.Any())
            {
                throw new Exception("Sepetinizde ürün bulunmamaktadır.");
            }

            
            var totalAmount = cart.CartItems.Sum(item => item.Quantity * item.Price);

            
            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                TotalAmount = totalAmount,
                Status = "Beklemede", 
                OrderItems = cart.CartItems.Select(item => new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList()
            };

            
            await _orderRepository.AddAsync(order);

            
            await ClearCartAsync(userId);

            return order;
        }
    }
}
