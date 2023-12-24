using Microsoft.AspNetCore.Mvc;
using StoreApp.Areas;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

}