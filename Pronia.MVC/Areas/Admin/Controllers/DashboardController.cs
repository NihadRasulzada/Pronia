using Microsoft.AspNetCore.Mvc;
using Pronia.MVC.Areas.Admin.Controllers.Commons;

namespace Pronia.MVC.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
