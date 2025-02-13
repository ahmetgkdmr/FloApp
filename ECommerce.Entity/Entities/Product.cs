using ECommerce.Core;

namespace ECommerce.Entity.Entities //Veritabanı tablolarına karşılık gelen modeller bu katmanda yer alacak.
{
    public class Product : BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; } /*Bir product ın sadece bir kategorisi olduğu için*/
    }
}
