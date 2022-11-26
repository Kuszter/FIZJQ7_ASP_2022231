using FIZJQ7_ASP_2022231.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Infrastructure.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ShopContext _context;

        public CategoriesViewComponent(ShopContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync() => View(await _context.Categories.ToListAsync());
    }
}