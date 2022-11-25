using FIZJQ7_ASP_2022231.Infrastructure;
using FIZJQ7_ASP_2022231.Models;
using FIZJQ7_ASP_2022231.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FIZJQ7_ASP_2022231.Controllers
{
    public class CartController : Controller
    {
        private readonly ShopContext _context;

        public CartController(ShopContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem >> ("Cart")??new List<CartItem> ();

            CartViewModel cartvm = new()
            {
                cartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };


            return View(cartvm);
        }
    }
}
