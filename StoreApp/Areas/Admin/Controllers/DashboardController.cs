using Microsoft.AspNetCore.Mvc;
using StoreApp.Areas;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

}
