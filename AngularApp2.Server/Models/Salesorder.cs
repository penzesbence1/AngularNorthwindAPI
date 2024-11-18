﻿using System;
using System.Collections.Generic;

namespace NorthwindAPI_beadando.Models;

public partial class Salesorder
{
    public int Orderid { get; set; }

    public string? Custid { get; set; }

    public int? Empid { get; set; }

    public DateTime? Orderdate { get; set; }

    public DateTime? Requireddate { get; set; }

    public DateTime? Shippeddate { get; set; }

    public int? Shipperid { get; set; }

    public decimal? Freight { get; set; }

    public string? Shipname { get; set; }

    public string? Shipaddress { get; set; }

    public string? Shipcity { get; set; }

    public string? Shipregion { get; set; }

    public string? Shippostalcode { get; set; }

    public string? Shipcountry { get; set; }
}
