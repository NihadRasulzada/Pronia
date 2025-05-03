using Pronia.MVC.Models;

namespace Pronia.MVC.ViewModels
{
    public class Home_VM
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Slider> Sliders { get; set; }
    }
}
