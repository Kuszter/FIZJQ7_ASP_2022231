using FIZJQ7_ASP_2022231.Infrastructure;
using FIZJQ7_ASP_2022231.Models;
using Microsoft.EntityFrameworkCore;


namespace FIZJQ7_ASP_2022231.Infrastructure
{
    public class SeedData
    {
        public static void SeedDatabase(ShopContext context)
        {
            context.Database.Migrate();

            if (!context.Products.Any())
            {
                Category fruits = new Category { Name = "Fruits", Slug = "fruits" };
                Category shirts = new Category { Name = "Shirts", Slug = "shirts" };

                context.Products.AddRange(
                        new Product
                        {
                            Name = "Alma",
                            Slug = "alma",
                            Description = "Almák",
                            Price = 1,
                            Category = fruits,
                            Image = "apples.jpg"
                        },
                        new Product
                        {
                            Name = "Banán",
                            Slug = "bananan",
                            Description = "1. osztályú lédig banán",
                            Price = 3,
                            Category = fruits,
                            Image = "bananas.jpg"
                        },
                        new Product
                        {
                            Name = "Dinnye",
                            Slug = "dinnye",
                            Description = "Mézédes görögdinnye",
                            Price = 1,
                            Category = fruits,
                            Image = "watermelon.jpg"
                        },
                        new Product
                        {
                            Name = "Grapefruit",
                            Slug = "grapefruit",
                            Description = "Grapefruit",
                            Price = 2,
                            Category = fruits,
                            Image = "grapefruit.jpg"
                        },
                        new Product
                        {
                            Name = "Fehér póló",
                            Slug = "feher-polo",
                            Description = "L",
                            Price =6,
                            Category = shirts,
                            Image = "white shirt.jpg"
                        },
                        new Product
                        {
                            Name = "Fekete póló",
                            Slug = "fekete-polo",
                            Description = "Fekete póló",
                            Price = 8,
                            Category = shirts,
                            Image = "black shirt.jpg"
                        },
                        new Product
                        {
                            Name = "Citrom póló",
                            Slug = "citrom-polo",
                            Description = "Sárga póló",
                            Price = 12,
                            Category = shirts,
                            Image = "yellow shirt.jpg"
                        },
                        new Product
                        {
                            Name = "Szürke póló",
                            Slug = "szurke-polo",
                            Description = "Szürke póló",
                            Price = 13,
                            Category = shirts,
                            Image = "grey shirt.jpg"
                        }
                );

                context.SaveChanges();
            }
        }
    }
}