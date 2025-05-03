using Pronia.MVC.Models.Commons;

namespace Pronia.MVC.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
