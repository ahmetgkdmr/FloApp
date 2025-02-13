using ECommerce.Core;
using ECommerce.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity
{
    public class Notification : BaseEntity
    {
        public int UserId { get; set; } 
        public string Type { get; set; }
        public string Message { get; set; } 
        public bool IsSent { get; set; } 
        public DateTime SentDate { get; set; }
        public virtual User User { get; set; } 
    }
}
