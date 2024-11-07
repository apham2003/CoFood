using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FoodOrderWeb.Models;
using FoodOrderWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FoodOrderWeb.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IVnPayServices _vnPayServices;
        private readonly Exe101Gr3G22Context _db;

        public PaymentController(IVnPayServices vnPayServices, Exe101Gr3G22Context db)
        {
            _vnPayServices = vnPayServices;
            _db = db;
        }
         [Authorize]
         public IActionResult Return()
        {
            var response = _vnPayServices.PaymentExcute(Request.Query);
            if (response == null || response.VnPayResponseCode != "00")
            {
                return RedirectToAction("Index", "Error");
            }
            return View();
        }
    }
}