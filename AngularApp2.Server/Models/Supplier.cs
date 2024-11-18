﻿using System;
using System.Collections.Generic;

namespace NorthwindAPI_beadando.Models;

public partial class Supplier
{
    public int Supplierid { get; set; }

    public string Companyname { get; set; } = null!;

    public string? Contactname { get; set; }

    public string? Contacttitle { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Region { get; set; }

    public string? Postalcode { get; set; }

    public string? Country { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? Homepage { get; set; }
}
