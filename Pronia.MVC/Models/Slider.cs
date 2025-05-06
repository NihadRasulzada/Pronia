using System.ComponentModel.DataAnnotations.Schema;
using Pronia.MVC.Models.Commons;

namespace Pronia.MVC.Models
{
    public class Slider : BaseEntity
    {
        public string Offer { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
