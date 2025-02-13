using ECommerce.Core;

namespace ECommerce.Entity.Entities
{
    public class UserType : BaseEntity
    {
        public string UserTypeName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
