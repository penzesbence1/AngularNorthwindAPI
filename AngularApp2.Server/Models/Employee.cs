using System;
using System.Collections.Generic;

namespace NorthwindAPI_beadando.Models;

public partial class Employee
{
    public int Empid { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string? Title { get; set; }

    public string? Titleofcourtesy { get; set; }

    public DateTime? Birthdate { get; set; }

    public DateTime? Hiredate { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Region { get; set; }

    public string? Postalcode { get; set; }

    public string? Country { get; set; }

    public string? Phone { get; set; }

    public string? Extension { get; set; }

    public byte[]? Photo { get; set; }

    public string? Notes { get; set; }

    public int? Mgrid { get; set; }

    public string? Photopath { get; set; }
}
