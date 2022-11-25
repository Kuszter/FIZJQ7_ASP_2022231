using FIZJQ7_ASP_2022231.Infrastructure;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShopContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionString:DbConnection"]);
}
);


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.IsEssential = true;
}
);

// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:existscontroller=Products}/{action=Index}/{id?}");


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
