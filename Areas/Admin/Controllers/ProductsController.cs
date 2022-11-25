using FIZJQ7_ASP_2022231.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FIZJQ7_ASP_2022231.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ShopContext _context;

        public ProductsController(ShopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
