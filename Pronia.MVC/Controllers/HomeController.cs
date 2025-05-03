using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.MVC.DAL;
using Pronia.MVC.Models;
using Pronia.MVC.ViewModels;

namespace Pronia.MVC.Controllers
{
    public class HomeController : Controller
    {
        readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<Product> products = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Category).ToListAsync();
            ICollection<Slider> sliders = await _context.Sliders.ToListAsync();
            Home_VM vM = new Home_VM
            {
                Products = products,
                Sliders = sliders
            };
            return View(vM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
