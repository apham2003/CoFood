using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FoodOrderWeb.Models;
using FoodOrderWeb.MyUtil;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
namespace FoodOrderWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly Exe101Gr3G22Context _db;
        private readonly ISendEmail _sendEmail;

        public AccountController(Exe101Gr3G22Context db, ISendEmail sendEmail)
        {
            _db = db;
            _sendEmail = sendEmail;
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CheckAccount()
        {
            string email = TempData["email"] as string;
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login", "Account");
            }
            Account account = _db.Accounts.FirstOrDefault(a => a.AccGmail == email);
            if (account != null)
            {
                string accountJon = JsonConvert.SerializeObject(account);
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(3);
                option.Path = "/";
                Response.Cookies.Append("Account", accountJon, option);
                String accountJonn = JsonConvert.SerializeObject(account);
                HttpContext.Session.SetString("AccGmail", account.AccGmail);
                _sendEmail.SendEmailAsync(email, "Chào Mừng Bạn Đến Với Cồ Food");
                return RedirectToAction("Index", "Product");
            }
            else
            {
                Account acc = new Account();
                acc.AccGmail = email;
                acc.AccPassword = "c5fb9e789d0f5e5d7f22668ef147c271";
                _db.Accounts.Add(acc);
                _db.SaveChanges();
                ViewData["email"] = email;
                string accountJon = JsonConvert.SerializeObject(acc);
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(3);
                option.Path = "/";
                Response.Cookies.Append("Account", accountJon, option);
                String accountJonn = JsonConvert.SerializeObject(acc);
                //HttpContext.Session.SetString("AccGmail", acc.AccGmail);
                _sendEmail.SendEmailAsync(email, "Chào Mừng Bạn Đến Với Cồ Food");
                return RedirectToAction("Index", "Product");
            }
        }


    }
}