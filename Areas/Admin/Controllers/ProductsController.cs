using FIZJQ7_ASP_2022231.Infrastructure;
using FIZJQ7_ASP_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FIZJQ7_ASP_2022231.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ShopContext _context;
        private readonly IWebHostEnvironment webHost;

        public ProductsController(ShopContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            this.webHost = webHost;
        }


        public async Task<IActionResult> Index(int p = 1)
        {
            int pageSize = 3;
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Products.Count() / pageSize);
            return View(await _context.Products.OrderByDescending(p => p.Id)
                .Include(p=>p.Category)
                .Skip((p - 1) * pageSize)
                .Take(pageSize).ToListAsync());


        }


        public  IActionResult Create(int p = 1)
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Products.Count() / pageSize);
            return View();
           


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);

            if (ModelState.IsValid)
            {
                product.Slug = product.Name.ToLower().Replace(" ", "-");

                var slug = await _context.Products.FirstOrDefaultAsync(p => p.Slug == product.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "A termék már létezik");
                    return View(product);
                }

                if (product.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(webHost.WebRootPath, "media/products");
                    string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;

                    string filePath = Path.Combine(uploadsDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await product.ImageUpload.CopyToAsync(fs);
                    fs.Close();

                    product.Image = imageName;
                }

                _context.Update(product);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Termék szerkesztve";
            }

            return View(product);
        }
    }
}

