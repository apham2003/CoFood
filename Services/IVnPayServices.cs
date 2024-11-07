using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using FoodOrderWeb.Models;

namespace FoodOrderWeb.Services
{
    public interface IVnPayServices
    {
        string CreateRequestUrl(HttpContext context, VnPayResqestModel vnPayment);
        VnPaymentResponseModel PaymentExcute(IQueryCollection collection);

    }
}