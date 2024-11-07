using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderWeb.MyUtil
{
    public interface ISendEmail
    {
        Task SendEmailAsync(string email, string subject);

    }
}