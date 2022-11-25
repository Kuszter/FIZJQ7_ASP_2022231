using FIZJQ7_ASP_2022231.Infrastructure;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShopContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionString:DbConnection"]);
}
);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


    app.MapControllerRoute(

        name: "products",
        pattern: "/products/{categorySlug?}",
defaults: new { controller = "Products", action = "Index" });



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<ShopContext>();
SeedData.SeedDatabase(context);

app.Run();
