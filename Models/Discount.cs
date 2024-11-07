using System;
using System.Collections.Generic;

namespace FoodOrderWeb.Models;

public partial class Discount
{
    public int DiscountId { get; set; }

    public int? DiscountValue { get; set; }

    public string DiscountNumber { get; set; }
}
