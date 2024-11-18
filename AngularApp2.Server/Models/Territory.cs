using System;
using System.Collections.Generic;

namespace NorthwindAPI_beadando.Models;

public partial class Territory
{
    public string Territoryid { get; set; } = null!;

    public string Territorydescription { get; set; } = null!;

    public int Regionid { get; set; }
}
