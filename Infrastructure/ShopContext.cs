using Microsoft.EntityFrameworkCore;

namespace FIZJQ7_ASP_2022231.Infrastructure
{
    public class ShopContext:DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options):base(options)
        {

        }
    }
}
