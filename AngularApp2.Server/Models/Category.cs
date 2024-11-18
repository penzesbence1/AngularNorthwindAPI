using System;
using System.Collections.Generic;

namespace NorthwindAPI_beadando.Models;

public partial class Category
{
    public int Categoryid { get; set; }

    public string Categoryname { get; set; } = null!;

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }
}
