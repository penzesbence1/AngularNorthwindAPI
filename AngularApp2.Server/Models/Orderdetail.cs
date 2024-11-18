using System;
using System.Collections.Generic;

namespace NorthwindAPI_beadando.Models;

public partial class Orderdetail
{
    public int Orderid { get; set; }

    public int Productid { get; set; }

    public decimal Unitprice { get; set; }

    public short Qty { get; set; }

    public decimal Discount { get; set; }
}
