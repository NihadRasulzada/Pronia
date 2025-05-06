using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.MVC.Abstractions.Storage;
using Pronia.MVC.Areas.Admin.Controllers.Commons;
using Pronia.MVC.DAL;
using Pronia.MVC.Models;

namespace Pronia.MVC.Areas.Admin.Controllers
{
    public class SliderController : BaseController
    {
        readonly AppDbContext _context;
        readonly IStorageService _storageService;
        readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Sliders.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View(slider);
            }

            if (slider.Photo == null || slider.Photo.Length == 0)
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa bir şəkil seçin.");
                return View(slider);
            }


            List<IFormFile> formFiles = new List<IFormFile> { slider.Photo };

            List<(string fileName, string pathOrContainerName)> values = await _storageService.UploadAsync(Path.Combine("Uploads", "Sliders"), formFiles);

            slider.ImgUrl = values[0].fileName;

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
