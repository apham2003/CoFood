using System;
using System.Collections.Generic;

namespace FoodOrderWeb.Models;

public partial class Account
{
    public int AccId { get; set; }

    public string AccGmail { get; set; }

    public string AccPassword { get; set; }
}
