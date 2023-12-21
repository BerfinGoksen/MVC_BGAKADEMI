using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Entities.Models;

namespace StoreApp.Controllers
{
    //kolay yoldan veritabanı erişimi
    public class ProductController : Controller
    {
        private readonly RepositoryContext _context;
        public ProductController(RepositoryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Products.OrderBy(p => p.ProductName).ToList();
            return View(model);
        }
        public IActionResult Get(int id)
        {
            Product product = _context.Products.First(p => p.ProductId.Equals(id));
            return View(product);
        }
    }
}