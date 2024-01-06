using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {

        private readonly IServiceManager _manager;
        //private readonly Cart _cart;

        public OrderController(IServiceManager manager)//, Cart cart)
        {
            _manager = manager;
            // _cart = cart;
        }
        public IActionResult Index()
        {
            var orders = _manager.OrderService.Orders;
            return View(orders);
        }

        [HttpPost]
        public IActionResult Complete([FromForm] int id)
        {
            _manager.OrderService.Complete(id);
            return RedirectToAction("Index");
        }


    }
}