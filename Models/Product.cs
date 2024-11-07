using System;
using System.Collections.Generic;

namespace FoodOrderWeb.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public string ProductCategory { get; set; }

    public int? ProductPrice { get; set; }

    public string ProductDescription { get; set; }

    public string ProductImage { get; set; }

    public int? ShopId { get; set; }
}
