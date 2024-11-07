using System;
using System.Collections.Generic;

namespace FoodOrderWeb.Models;

public partial class Shop
{
    public int ShopId { get; set; }

    public string ShopName { get; set; }

    public string ShopDescription { get; set; }

    public string ShopOpening { get; set; }

    public string ShopAddress { get; set; }

    public string ShopImage { get; set; }
}
