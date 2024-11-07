using FoodOrderWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
namespace FoodOrderWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly Exe101Gr3G22Context _db;
        private Account account;
        public ProductController(Exe101Gr3G22Context db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductDetail(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.ProductId == id);
            Product pro = new Product();
            pro = product;
            if (pro == null)
            {
                return View("Index", "Index");
            }
            return View("ProductDetail", pro);
        }
    }
}
