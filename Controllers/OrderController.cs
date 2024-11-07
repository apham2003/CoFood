using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FoodOrderWeb.Models;
using FoodOrderWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FoodOrderWeb.Controllers
{
    public class OrderController : Controller
    {
        private readonly Exe101Gr3G22Context _db;
        private readonly IVnPayServices _vnPayServices;
        public OrderController(Exe101Gr3G22Context db, IVnPayServices vnPayServices)
        {
            _db = db;
            _vnPayServices = vnPayServices;
        }
        public IActionResult Order()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Payment(IFormCollection form)
        {
            string name = form["txtName"];
            string phone = form["txtPhone"];
            string emailFrom = "anhtpce172081@fpt.edu.vn";
            string address = form["txtAddress"];
            string payment = form["txtpayment"];
            double total = Double.Parse(form["amount"]);


            switch (payment)
            {
                case "QuetMaQR":
                case "TKNganHang":
                case "QuocTe":
                    VnPayResqestModel vnPayment = new VnPayResqestModel
                    {
                        amount = total,
                        CreatedDate = DateTime.Now,
                        OrderId = 3,
                        fullName = name,
                        phone = phone,
                        email = emailFrom,
                        address = address
                    };
                    return Redirect(_vnPayServices.CreateRequestUrl(HttpContext, vnPayment));
                case "NhanHang":
                    try
                    {
                        _db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return RedirectToAction("Index", "Product");
                    }
                    _db.SaveChanges();
                    break;
            }

            return RedirectToAction("Thanks", "Error");
        }

    }
}