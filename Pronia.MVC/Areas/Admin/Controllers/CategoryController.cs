using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.MVC.Areas.Admin.Controllers.Commons;
using Pronia.MVC.DAL;
using Pronia.MVC.Models;

namespace Pronia.MVC.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        readonly AppDbContext _appDbContext;

        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _appDbContext.Categories.ToListAsync();
            return View(categories);
        }

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            category.CreatedDate = DateTime.UtcNow.AddHours(4);
            category.UpdatedDate = null;

            await _appDbContext.Categories.AddAsync(category);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var category = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id,Category updatedCategory)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var category = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(updatedCategory);
            }

            category.Name = updatedCategory.Name;
            category.UpdatedDate = DateTime.UtcNow.AddHours(4);

            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        #endregion

        #region Activity (Activate/Deactivate)
        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var category = await _appDbContext.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            category.IsDeactive = !category.IsDeactive;
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        #endregion
    }
}
