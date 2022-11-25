using FIZJQ7_ASP_2022231.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FIZJQ7_ASP_2022231.Controllers
{
    public class ProductsController : Controller
    {
        private ShopContext context;
       public ProductsController(ShopContext context)
        {
                this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
