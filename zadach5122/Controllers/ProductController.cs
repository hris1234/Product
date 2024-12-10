using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using zadach5122.Data;
using zadach5122.Models;
using zadach5122.Data.Models;


namespace zadach5122.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext db;

        public ProductController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult All() 
        { 
            return View();
        }

        public IActionResult Add(ProductViewModel model)
        {
            Product product = new Product
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Quantity = model.Quantity,
            };
            db.Add(product);
            db.SaveChanges();
            return Redirect("/Home/Index");
        }
        public IActionResult All()
        {
            List<ProductViewModel> model = db.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
               Price= x.Price,
               Quantity= x.Quantity,
            }).ToList();
            return View(model);
        }
        
    }
}
