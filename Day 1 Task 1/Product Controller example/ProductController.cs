using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
           // ViewBag.Message = "Data Sharing using ViewBag";

            List<Product> products = new List<Product>()
            {
                new Product(){ProductId=1022,ProductName="Printer",UnitPrice=2400,Quantity=5},
                new Product(){ProductId=2022,ProductName="Keyboard",UnitPrice=1240,Quantity=4},
                new Product(){ProductId=3022,ProductName="Mouse",UnitPrice=4000,Quantity=3}
            };
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }


        // public IActionResult Create(int pid, string pname)

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            /*
                // logic to process data
                double  total = obj.UnitPrice * obj.Quantity;
                ViewBag.Total = total;
                ViewBag.RequestType = Request.Method;
                return View();
            */

            return RedirectToAction("Index");
            // return RedirectToAction("Index", "Home");
        }


        public IActionResult Details(int id)
        {

            List<Product> products = new List<Product>() {
                new Product(){ ProductId = 1022, ProductName = "Printer", UnitPrice = 2400, Quantity = 5 },
                new Product(){ ProductId = 1023, ProductName = "Keyboard", UnitPrice = 1200, Quantity = 3 },
                new Product(){ ProductId = 1024, ProductName = "LG Mouse", UnitPrice = 900, Quantity = 4 }
            };


            Product obj = products.Find(item => item.ProductId == id);


            return View(obj);
        }

    }
}
    

