using ECommerce.Core;

/*Entity classında User - UserType ları oluştur. Aynı Product Category mantığı gibi 1 user 1 tane usertype a bağlı olabilir.
 * 1 usertype birden fazla Usera bağlı olabilir.
 AppDbContext de yeni 2 entity ni oluştur. Servisler kısmında servislerini yaz. Sonra apisini yaz. Swagger da UserType a bir userType ekle
Sonrasında user a istek atıp user ı oluştur.*/


namespace ECommerce.Entity.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public int UserTypeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public virtual ICollection<UserType> UserTypes { get; set; } = new List<UserType>();
    }
}
