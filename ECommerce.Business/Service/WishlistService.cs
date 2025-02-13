using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Entity;
using ECommerce.Repository;
using ECommerce.Repository.Repository;

namespace ECommerce.Business
{
    public class WishlistService
    {
        private readonly IRepository<Wishlist> _wishlistRepository;

        public WishlistService(IRepository<Wishlist> wishlistRepository)
        {
            _wishlistRepository = wishlistRepository;
        }

        
        public void AddToWishlist(int userId, int productId)
        {
            var wishlistItem = new Wishlist { UserId = userId, ProductId = productId };
            _wishlistRepository.Add(wishlistItem);
        }

        
        public void RemoveFromWishlist(int userId, int productId)
        {
            var wishlistItem = _wishlistRepository
                .Find(w => w.UserId == userId && w.ProductId == productId)
                .FirstOrDefault();

            if (wishlistItem != null)
            {
                _wishlistRepository.Delete(wishlistItem);
            }
        }

        public List<Wishlist> GetWishlistByUserId(int userId)
        {
            return _wishlistRepository.Find(w => w.UserId == userId).ToList();
        }
    }
}

