using System;
using System.Collections.Generic;

namespace FoodOrderWeb.Models;

public partial class WishList
{
    public int WishlistId { get; set; }

    public int? AccId { get; set; }

    public int? ProductId { get; set; }
}
