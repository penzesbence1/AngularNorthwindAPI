using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NorthwindAPI_beadando.Models;

public partial class NorthwindContext : DbContext
{
    public NorthwindContext()
    {
    }

    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Customercustomerdemographic> Customercustomerdemographics { get; set; }

    public virtual DbSet<Customerdemographic> Customerdemographics { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employeeterritory> Employeeterritories { get; set; }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Salesorder> Salesorders { get; set; }

    public virtual DbSet<Shipper> Shippers { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Territory> Territories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=northwind;Username=postgres;Password=pass");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("en_AU.UTF-8");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(15)
                .HasColumnName("categoryname");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Picture).HasColumnName("picture");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Custid).HasName("customer_pkey");

            entity.ToTable("customer");

            entity.Property(e => e.Custid).HasColumnName("custid");
            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .HasColumnName("city");
            entity.Property(e => e.Companyname)
                .HasMaxLength(40)
                .HasColumnName("companyname");
            entity.Property(e => e.Contactname)
                .HasMaxLength(30)
                .HasColumnName("contactname");
            entity.Property(e => e.Contacttitle)
                .HasMaxLength(30)
                .HasColumnName("contacttitle");
            entity.Property(e => e.Country)
                .HasMaxLength(15)
                .HasColumnName("country");
            entity.Property(e => e.Fax)
                .HasMaxLength(24)
                .HasColumnName("fax");
            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasColumnName("phone");
            entity.Property(e => e.Postalcode)
                .HasMaxLength(10)
                .HasColumnName("postalcode");
            entity.Property(e => e.Region)
                .HasMaxLength(15)
                .HasColumnName("region");
        });

        modelBuilder.Entity<Customercustomerdemographic>(entity =>
        {
            entity.HasKey(e => new { e.Customerid, e.Customertypeid }).HasName("customercustomerdemographic_pkey");

            entity.ToTable("customercustomerdemographic");

            entity.Property(e => e.Customerid)
                .HasMaxLength(5)
                .HasColumnName("customerid");
            entity.Property(e => e.Customertypeid)
                .HasMaxLength(10)
                .HasColumnName("customertypeid");
        });

        modelBuilder.Entity<Customerdemographic>(entity =>
        {
            entity.HasKey(e => e.Customertypeid).HasName("customerdemographic_pkey");

            entity.ToTable("customerdemographic");

            entity.Property(e => e.Customertypeid)
                .HasMaxLength(10)
                .HasColumnName("customertypeid");
            entity.Property(e => e.Customerdesc).HasColumnName("customerdesc");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Empid).HasName("employee_pkey");

            entity.ToTable("employee");

            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .HasColumnName("address");
            entity.Property(e => e.Birthdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("birthdate");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(15)
                .HasColumnName("country");
            entity.Property(e => e.Extension)
                .HasMaxLength(4)
                .HasColumnName("extension");
            entity.Property(e => e.Firstname)
                .HasMaxLength(10)
                .HasColumnName("firstname");
            entity.Property(e => e.Hiredate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("hiredate");
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .HasColumnName("lastname");
            entity.Property(e => e.Mgrid).HasColumnName("mgrid");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasColumnName("phone");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.Photopath)
                .HasMaxLength(255)
                .HasColumnName("photopath");
            entity.Property(e => e.Postalcode)
                .HasMaxLength(10)
                .HasColumnName("postalcode");
            entity.Property(e => e.Region)
                .HasMaxLength(15)
                .HasColumnName("region");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");
            entity.Property(e => e.Titleofcourtesy)
                .HasMaxLength(25)
                .HasColumnName("titleofcourtesy");
        });

        modelBuilder.Entity<Employeeterritory>(entity =>
        {
            entity.HasKey(e => new { e.Employeeid, e.Territoryid }).HasName("employeeterritory_pkey");

            entity.ToTable("employeeterritory");

            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Territoryid)
                .HasMaxLength(20)
                .HasColumnName("territoryid");
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("orderdetail");

            entity.Property(e => e.Discount)
                .HasPrecision(10, 2)
                .HasColumnName("discount");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.Unitprice)
                .HasPrecision(10, 2)
                .HasColumnName("unitprice");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Productid).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Discontinued)
                .HasMaxLength(1)
                .HasColumnName("discontinued");
            entity.Property(e => e.Productname)
                .HasMaxLength(40)
                .HasColumnName("productname");
            entity.Property(e => e.Quantityperunit)
                .HasMaxLength(20)
                .HasColumnName("quantityperunit");
            entity.Property(e => e.Reorderlevel).HasColumnName("reorderlevel");
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
            entity.Property(e => e.Unitprice)
                .HasPrecision(10, 2)
                .HasColumnName("unitprice");
            entity.Property(e => e.Unitsinstock).HasColumnName("unitsinstock");
            entity.Property(e => e.Unitsonorder).HasColumnName("unitsonorder");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Regionid).HasName("region_pkey");

            entity.ToTable("region");

            entity.Property(e => e.Regionid)
                .ValueGeneratedNever()
                .HasColumnName("regionid");
            entity.Property(e => e.Regiondescription)
                .HasMaxLength(50)
                .HasColumnName("regiondescription");
        });

        modelBuilder.Entity<Salesorder>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("salesorder_pkey");

            entity.ToTable("salesorder");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Custid)
                .HasMaxLength(15)
                .HasColumnName("custid");
            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Freight)
                .HasPrecision(10, 2)
                .HasColumnName("freight");
            entity.Property(e => e.Orderdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("orderdate");
            entity.Property(e => e.Requireddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("requireddate");
            entity.Property(e => e.Shipaddress)
                .HasMaxLength(60)
                .HasColumnName("shipaddress");
            entity.Property(e => e.Shipcity)
                .HasMaxLength(15)
                .HasColumnName("shipcity");
            entity.Property(e => e.Shipcountry)
                .HasMaxLength(15)
                .HasColumnName("shipcountry");
            entity.Property(e => e.Shipname)
                .HasMaxLength(40)
                .HasColumnName("shipname");
            entity.Property(e => e.Shippeddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("shippeddate");
            entity.Property(e => e.Shipperid).HasColumnName("shipperid");
            entity.Property(e => e.Shippostalcode)
                .HasMaxLength(10)
                .HasColumnName("shippostalcode");
            entity.Property(e => e.Shipregion)
                .HasMaxLength(15)
                .HasColumnName("shipregion");
        });

        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.HasKey(e => e.Shipperid).HasName("shipper_pkey");

            entity.ToTable("shipper");

            entity.Property(e => e.Shipperid).HasColumnName("shipperid");
            entity.Property(e => e.Companyname)
                .HasMaxLength(40)
                .HasColumnName("companyname");
            entity.Property(e => e.Phone)
                .HasMaxLength(44)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Supplierid).HasName("supplier_pkey");

            entity.ToTable("supplier");

            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .HasColumnName("city");
            entity.Property(e => e.Companyname)
                .HasMaxLength(40)
                .HasColumnName("companyname");
            entity.Property(e => e.Contactname)
                .HasMaxLength(30)
                .HasColumnName("contactname");
            entity.Property(e => e.Contacttitle)
                .HasMaxLength(30)
                .HasColumnName("contacttitle");
            entity.Property(e => e.Country)
                .HasMaxLength(15)
                .HasColumnName("country");
            entity.Property(e => e.Fax)
                .HasMaxLength(24)
                .HasColumnName("fax");
            entity.Property(e => e.Homepage).HasColumnName("homepage");
            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasColumnName("phone");
            entity.Property(e => e.Postalcode)
                .HasMaxLength(10)
                .HasColumnName("postalcode");
            entity.Property(e => e.Region)
                .HasMaxLength(15)
                .HasColumnName("region");
        });

        modelBuilder.Entity<Territory>(entity =>
        {
            entity.HasKey(e => e.Territoryid).HasName("territory_pkey");

            entity.ToTable("territory");

            entity.Property(e => e.Territoryid)
                .HasMaxLength(20)
                .HasColumnName("territoryid");
            entity.Property(e => e.Regionid).HasColumnName("regionid");
            entity.Property(e => e.Territorydescription)
                .HasMaxLength(50)
                .HasColumnName("territorydescription");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
