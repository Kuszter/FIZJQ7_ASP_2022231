using FIZJQ7_ASP_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIZJQ7_ASP_2022231.Infrastructure.Components
{
    public class SmallCarViwComponent : ViewComponent
    {
         
        public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            SmallCarViwComponent smallCarViw;

            if (cart==null||cart.Count==0)
            {
                smallCarViw = null;
            }
            else
            {
                smallCarViw = new()
                {
                    NumberOfItems = cart.Sum(x => x.Quantity),
                    TotalAmount = cart.Sum(x => x.Quantity * x.Price)
                };
            }
            return View(smallCarViw);
        }
        
        
        
        
        
    }
}
