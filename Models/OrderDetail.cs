using System;
using System.Collections.Generic;

namespace FoodOrderWeb.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int? OrderDetailPrice { get; set; }

    public int? OrderDetailQuantity { get; set; }

    public decimal? OrderDetailTotalMoney { get; set; }
}
