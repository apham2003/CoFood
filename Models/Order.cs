using System;
using System.Collections.Generic;

namespace FoodOrderWeb.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? AccId { get; set; }

    public string OrderDate { get; set; }

    public string OrderStatus { get; set; }

    public string OrderTotalMoney { get; set; }

    public string OrderPhoneNumber { get; set; }

    public string OrderAddress { get; set; }

    public string OrderName { get; set; }
}
