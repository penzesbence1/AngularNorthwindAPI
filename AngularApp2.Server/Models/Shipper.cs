using System;
using System.Collections.Generic;

namespace NorthwindAPI_beadando.Models;

public partial class Shipper
{
    public int Shipperid { get; set; }

    public string Companyname { get; set; } = null!;

    public string? Phone { get; set; }
}
