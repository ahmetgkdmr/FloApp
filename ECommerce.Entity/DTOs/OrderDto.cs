using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.DTOs
{
    public class OrderDto
    {
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}
