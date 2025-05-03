using Microsoft.EntityFrameworkCore;
using Pronia.MVC.Models.Commons;

namespace Pronia.MVC.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
