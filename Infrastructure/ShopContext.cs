using FIZJQ7_ASP_2022231.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FIZJQ7_ASP_2022231.Infrastructure
{
    public class ShopContext : IdentityDbContext<AppUser>
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        { }
        public DbSet<Product> Products { get; set; }
            public DbSet<Category> Categories { get; set; }
    

        }   
 }





