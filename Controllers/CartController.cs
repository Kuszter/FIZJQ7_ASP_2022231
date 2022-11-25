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
        public async Task <IActionResult> Add(long id)
        {
            Product product = await _context.Products.FindAsync(id);
            List<CartItem> cartItems = HttpContext.Session.GetJson<List<CartItem>>("Car") ?? new List<CartItem>();
            CartItem cartItem = cartItems.Where(x => x.ProductId == id).FirstOrDefault();
            if (cartItem==null)
            {
                cartItems.Add(new CartItem(product));
            }
            else
            {
                cartItem.Quantity++;
            }
            HttpContext.Session.SetJson("Cart", cartItems);
            TempData["Succes"] = "A termék sikeresen hozzáadva!";
            return Redirect(Request.Headers["Refer"].ToString());
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

        public async Task<IActionResult> Decrease(long id)
        {

            List<CartItem> cartItems = HttpContext.Session.GetJson<List<CartItem>>("Car");
            CartItem cartItem = cartItems.Where(x => x.ProductId == id).FirstOrDefault();
            if (cartItem.Quantity>1)
            {
                cartItem.Quantity--;
            }
            else
            {
                cartItems.RemoveAll(x => x.ProductId == id);
            }
            if (cartItems.Count==0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cartItems);
                
            }
           
            TempData["Succes"] = "A termék sikeresen eltávolítva!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(long id)
        {

            List<CartItem> cartItems = HttpContext.Session.GetJson<List<CartItem>>("Car");
           cartItems.RemoveAll(x => x.ProductId == id);
            
          
            if (cartItems.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cartItems);

            }

            TempData["Succes"] = "A termék sikeresen eltávolítva!";
            return RedirectToAction("Index");
        }

        public  IActionResult Clear()
        {

            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index");
        }

    }
}
