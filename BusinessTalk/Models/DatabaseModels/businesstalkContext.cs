using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BusinessTalk.Models.DatabaseModels
{
    public partial class BusinessTalkContext : DbContext
    {
        public BusinessTalkContext(DbContextOptions<BusinessTalkContext> options)
    : base(options)
        { }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Customeraddress> Customeraddress { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Expenses> Expenses { get; set; }
        public virtual DbSet<Expensetypes> Expensetypes { get; set; }
        public virtual DbSet<Loancustomers> Loancustomers { get; set; }
        public virtual DbSet<Loanhistory> Loanhistory { get; set; }
        public virtual DbSet<Loans> Loans { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Productlistpricehistory> Productlistpricehistory { get; set; }
        public virtual DbSet<Productvendor> Productvendor { get; set; }
        public virtual DbSet<Purchaseorderdetail> Purchaseorderdetail { get; set; }
        public virtual DbSet<Purchaseorderheader> Purchaseorderheader { get; set; }
        public virtual DbSet<Salesorderdetail> Salesorderdetail { get; set; }
        public virtual DbSet<Salesorderheader> Salesorderheader { get; set; }
        public virtual DbSet<Transactionhistory> Transactionhistory { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<Vendorcontact> Vendorcontact { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Rowguid)
                    .IsRequired()
                    .HasColumnName("rowguid")
                    .HasColumnType("char(38)");
            });

            modelBuilder.Entity<Customeraddress>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("customeraddress");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(256);

                entity.Property(e => e.ContactNumber).HasMaxLength(256);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Rowguid)
                    .IsRequired()
                    .HasColumnName("rowguid")
                    .HasColumnType("char(38)");

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.Customeraddress)
                    .HasForeignKey<Customeraddress>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customeraddress_ibfk_1");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CurrentFlag).HasColumnType("bit(1)");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("char(1)");

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.LoginId)
                    .IsRequired()
                    .HasColumnName("LoginID")
                    .HasMaxLength(256);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Rowguid)
                    .IsRequired()
                    .HasColumnName("rowguid")
                    .HasColumnType("char(38)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Expenses>(entity =>
            {
                entity.HasKey(e => e.ExpenseId);

                entity.ToTable("expenses");

                entity.HasIndex(e => e.ExpenseTypeId)
                    .HasName("ExpenseTypeId");

                entity.Property(e => e.ExpenseId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.AmountSpent).HasColumnType("decimal(13,4)");

                entity.Property(e => e.ExpenseTypeId).HasColumnType("int(11)");

                entity.Property(e => e.SpentDate).HasColumnType("datetime");

                entity.HasOne(d => d.ExpenseType)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.ExpenseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("expenses_ibfk_1");
            });

            modelBuilder.Entity<Expensetypes>(entity =>
            {
                entity.HasKey(e => e.ExpenseTypeId);

                entity.ToTable("expensetypes");

                entity.Property(e => e.ExpenseTypeId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Loancustomers>(entity =>
            {
                entity.HasKey(e => e.BorrowerId);

                entity.ToTable("loancustomers");

                entity.Property(e => e.BorrowerId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(256);

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Rowguid)
                    .IsRequired()
                    .HasColumnName("rowguid")
                    .HasColumnType("char(38)");
            });

            modelBuilder.Entity<Loanhistory>(entity =>
            {
                entity.HasKey(e => e.LoanId);

                entity.ToTable("loanhistory");

                entity.Property(e => e.LoanId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.AmountPaid).HasColumnType("decimal(13,4)");

                entity.Property(e => e.BorrowerId).HasColumnType("int(11)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Loan)
                    .WithOne(p => p.Loanhistory)
                    .HasForeignKey<Loanhistory>(d => d.LoanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("loanhistory_ibfk_1");
            });

            modelBuilder.Entity<Loans>(entity =>
            {
                entity.HasKey(e => e.LoanId);

                entity.ToTable("loans");

                entity.Property(e => e.LoanId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.LoanAmount).HasColumnType("decimal(13,4)");

                entity.Property(e => e.LoanCompletionDate).HasColumnType("datetime");

                entity.Property(e => e.LoanTakenDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnType("tinyint(4)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Color).HasMaxLength(15);

                entity.Property(e => e.DiscontinuedDate).HasColumnType("datetime");

                entity.Property(e => e.ListPrice).HasColumnType("decimal(13,4)");

                entity.Property(e => e.MakeFlag).HasColumnType("bit(1)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProductModelId)
                    .HasColumnName("ProductModelID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProductNumber)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.ProductSubcategoryId)
                    .HasColumnName("ProductSubcategoryID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ReorderPoint).HasColumnType("smallint(6)");

                entity.Property(e => e.Rowguid)
                    .IsRequired()
                    .HasColumnName("rowguid")
                    .HasColumnType("char(38)");

                entity.Property(e => e.SellEndDate).HasColumnType("datetime");

                entity.Property(e => e.SellStartDate).HasColumnType("datetime");

                entity.Property(e => e.Size).HasMaxLength(5);

                entity.Property(e => e.SizeUnitMeasureCode).HasColumnType("char(3)");

                entity.Property(e => e.StandardCost).HasColumnType("decimal(13,4)");

                entity.Property(e => e.Style).HasColumnType("char(2)");

                entity.Property(e => e.Weight).HasColumnType("decimal(8,2)");

                entity.Property(e => e.WeightUnitMeasureCode).HasColumnType("char(3)");
            });

            modelBuilder.Entity<Productlistpricehistory>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("productlistpricehistory");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ListPrice).HasColumnType("decimal(13,4)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.Productlistpricehistory)
                    .HasForeignKey<Productlistpricehistory>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productlistpricehistory_ibfk_1");
            });

            modelBuilder.Entity<Productvendor>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("productvendor");

                entity.HasIndex(e => e.VendorId)
                    .HasName("VendorId");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.LastReceiptCost).HasColumnType("decimal(13,4)");

                entity.Property(e => e.LastReceiptDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OnOrderQty).HasColumnType("int(11)");

                entity.Property(e => e.StandardPrice).HasColumnType("decimal(13,4)");

                entity.Property(e => e.UnitMeasureCode).HasColumnType("char(3)");

                entity.Property(e => e.VendorId).HasColumnType("int(11)");

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.Productvendor)
                    .HasForeignKey<Productvendor>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productvendor_ibfk_1");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Productvendor)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productvendor_ibfk_2");
            });

            modelBuilder.Entity<Purchaseorderdetail>(entity =>
            {
                entity.HasKey(e => e.PurchaseOrderId);

                entity.ToTable("purchaseorderdetail");

                entity.Property(e => e.PurchaseOrderId)
                    .HasColumnName("PurchaseOrderID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Freight).HasColumnType("decimal(13,4)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderQty).HasColumnType("smallint(6)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PurchaseOrderDetailId)
                    .HasColumnName("PurchaseOrderDetailID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SubTotal).HasColumnType("decimal(13,4)");

                entity.Property(e => e.TaxAmt).HasColumnType("decimal(13,4)");

                entity.Property(e => e.TotalDue).HasColumnType("decimal(13,4)");

                entity.Property(e => e.VendorId).HasColumnType("int(11)");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithOne(p => p.Purchaseorderdetail)
                    .HasForeignKey<Purchaseorderdetail>(d => d.PurchaseOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("purchaseorderdetail_ibfk_1");
            });

            modelBuilder.Entity<Purchaseorderheader>(entity =>
            {
                entity.HasKey(e => e.PurchaseOrderId);

                entity.ToTable("purchaseorderheader");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("EmployeeId");

                entity.Property(e => e.PurchaseOrderId)
                    .HasColumnName("PurchaseOrderID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmployeeId).HasColumnType("int(11)");

                entity.Property(e => e.Freight).HasColumnType("decimal(13,4)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.RevisionNumber).HasColumnType("tinyint(4)");

                entity.Property(e => e.Status).HasColumnType("tinyint(4)");

                entity.Property(e => e.SubTotal).HasColumnType("decimal(13,4)");

                entity.Property(e => e.TaxAmt).HasColumnType("decimal(13,4)");

                entity.Property(e => e.TotalDue).HasColumnType("decimal(13,4)");

                entity.Property(e => e.VendorId).HasColumnType("int(11)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Purchaseorderheader)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("purchaseorderheader_ibfk_1");
            });

            modelBuilder.Entity<Salesorderdetail>(entity =>
            {
                entity.HasKey(e => e.SalesOrderId);

                entity.ToTable("salesorderdetail");

                entity.Property(e => e.SalesOrderId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.LineTotal).HasColumnType("decimal(13,4)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OrderQty).HasColumnType("smallint(6)");

                entity.Property(e => e.ProductId).HasColumnType("int(11)");

                entity.Property(e => e.Rowguid)
                    .IsRequired()
                    .HasColumnName("rowguid")
                    .HasColumnType("char(38)");

                entity.Property(e => e.SalesOrderDetailId).HasColumnType("int(11)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(13,4)");

                entity.HasOne(d => d.SalesOrder)
                    .WithOne(p => p.Salesorderdetail)
                    .HasForeignKey<Salesorderdetail>(d => d.SalesOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("salesorderdetail_ibfk_1");
            });

            modelBuilder.Entity<Salesorderheader>(entity =>
            {
                entity.HasKey(e => e.SalesOrderId);

                entity.ToTable("salesorderheader");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("EmployeeId");

                entity.Property(e => e.SalesOrderId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.EmployeeId).HasColumnType("int(11)");

                entity.Property(e => e.Freight).HasColumnType("decimal(13,4)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.RevisionNumber).HasColumnType("tinyint(4)");

                entity.Property(e => e.Rowguid)
                    .IsRequired()
                    .HasColumnName("rowguid")
                    .HasColumnType("char(38)");

                entity.Property(e => e.SalesOrderNumber)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnType("tinyint(4)");

                entity.Property(e => e.SubTotal).HasColumnType("decimal(13,4)");

                entity.Property(e => e.TaxAmt).HasColumnType("decimal(13,4)");

                entity.Property(e => e.TotalDue).HasColumnType("decimal(13,4)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Salesorderheader)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("salesorderheader_ibfk_1");
            });

            modelBuilder.Entity<Transactionhistory>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.ToTable("transactionhistory");

                entity.HasIndex(e => e.ProductId)
                    .HasName("ProductId");

                entity.Property(e => e.TransactionId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActualCost).HasColumnType("decimal(13,4)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnType("int(11)");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionType)
                    .IsRequired()
                    .HasColumnType("char(1)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Transactionhistory)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("transactionhistory_ibfk_1");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("vendor");

                entity.Property(e => e.VendorId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountNumber).HasMaxLength(30);

                entity.Property(e => e.ActiveFlag).HasColumnType("bit(1)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Vendorcontact>(entity =>
            {
                entity.HasKey(e => e.VendorId);

                entity.ToTable("vendorcontact");

                entity.Property(e => e.VendorId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActiveFlag).HasColumnType("bit(1)");

                entity.Property(e => e.ContactNumber1).HasMaxLength(30);

                entity.Property(e => e.ContactNumber2).HasMaxLength(30);

                entity.Property(e => e.ContactNumber3).HasMaxLength(30);

                entity.Property(e => e.ContactNumber4).HasMaxLength(30);

                entity.Property(e => e.ContactNumber5).HasMaxLength(30);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.VendorAddress).HasMaxLength(30);

                entity.HasOne(d => d.Vendor)
                    .WithOne(p => p.Vendorcontact)
                    .HasForeignKey<Vendorcontact>(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vendorcontact_ibfk_1");
            });
        }
    }
}
