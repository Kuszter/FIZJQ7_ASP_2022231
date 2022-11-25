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
                            Name = "Apples",
                            Slug = "apples",
                            Description = "Juicy apples",
                            Price = 1,
                            Category = fruits,
                            Image = "apples.jpg"
                        },
                        new Product
                        {
                            Name = "Bananas",
                            Slug = "bananas",
                            Description = "Fresh bananas",
                            Price = 3,
                            Category = fruits,
                            Image = "bananas.jpg"
                        },
                        new Product
                        {
                            Name = "Watermelon",
                            Slug = "watermelon",
                            Description = "Juicy watermelon",
                            Price = 1,
                            Category = fruits,
                            Image = "watermelon.jpg"
                        },
                        new Product
                        {
                            Name = "Grapefruit",
                            Slug = "grapefruit",
                            Description = "Juicy grapefruit",
                            Price = 2,
                            Category = fruits,
                            Image = "grapefruit.jpg"
                        },
                        new Product
                        {
                            Name = "White shirt",
                            Slug = "white-shirt",
                            Description = "White shirt",
                            Price =6,
                            Category = shirts,
                            Image = "white shirt.jpg"
                        },
                        new Product
                        {
                            Name = "Black shirt",
                            Slug = "black-shirt",
                            Description = "Black shirt",
                            Price = 8,
                            Category = shirts,
                            Image = "black shirt.jpg"
                        },
                        new Product
                        {
                            Name = "Yellow shirt",
                            Slug = "yellow-shirt",
                            Description = "Yellow shirt",
                            Price = 12,
                            Category = shirts,
                            Image = "yellow shirt.jpg"
                        },
                        new Product
                        {
                            Name = "Grey shirt",
                            Slug = "grey-shirt",
                            Description = "Grey shirt",
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