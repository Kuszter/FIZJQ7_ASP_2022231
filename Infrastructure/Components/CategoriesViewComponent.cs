using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIZJQ7_ASP_2022231.Infrastructure.Components
{
    public class CategoriesViewComponent:ViewComponent
    {
        private readonly ShopContext shopContext;
        public CategoriesViewComponent(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public async Task<IViewComponentResult> InvokeAsync() => View(await shopContext.Categories.ToListAsync());
    }
}
