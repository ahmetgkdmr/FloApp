using ECommerce.Core;
using ECommerce.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity
{
    public class Wishlist : BaseEntity
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}

