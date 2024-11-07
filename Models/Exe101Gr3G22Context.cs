using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderWeb.Models;

public partial class Exe101Gr3G22Context : DbContext
{
    public Exe101Gr3G22Context()
    {
    }

    public Exe101Gr3G22Context(DbContextOptions<Exe101Gr3G22Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<WishList> WishLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-J9CUM2CG;Database=exe101_gr3_g22;uid=sa;pwd=123;encrypt=true;trustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccId);

            entity.ToTable("Account");

            entity.Property(e => e.AccId).HasColumnName("acc_id");
            entity.Property(e => e.AccGmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("acc_gmail");
            entity.Property(e => e.AccPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("acc_password");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.ToTable("Discount");

            entity.Property(e => e.DiscountId).HasColumnName("discount_id");
            entity.Property(e => e.DiscountNumber)
                .HasMaxLength(50)
                .HasColumnName("discount_number");
            entity.Property(e => e.DiscountValue).HasColumnName("discount_value");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.AccId).HasColumnName("acc_id");
            entity.Property(e => e.OrderAddress)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("order_address");
            entity.Property(e => e.OrderDate)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("order_date");
            entity.Property(e => e.OrderName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("order_name");
            entity.Property(e => e.OrderPhoneNumber)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("order_phoneNumber");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("order_status");
            entity.Property(e => e.OrderTotalMoney)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("order_totalMoney");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.ToTable("Order_Detail");

            entity.Property(e => e.OrderDetailId).HasColumnName("orderDetail_id");
            entity.Property(e => e.OrderDetailPrice).HasColumnName("orderDetail_price");
            entity.Property(e => e.OrderDetailQuantity).HasColumnName("orderDetail_quantity");
            entity.Property(e => e.OrderDetailTotalMoney)
                .HasColumnType("money")
                .HasColumnName("orderDetail_totalMoney");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_Product]");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductCategory)
                .HasMaxLength(50)
                .HasColumnName("product_category");
            entity.Property(e => e.ProductDescription).HasColumnName("product_description");
            entity.Property(e => e.ProductImage).HasColumnName("product_image");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductPrice).HasColumnName("product_price");
            entity.Property(e => e.ShopId).HasColumnName("shop_id");
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.ToTable("Shop");

            entity.Property(e => e.ShopId).HasColumnName("shop_id");
            entity.Property(e => e.ShopAddress)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("shop_address");
            entity.Property(e => e.ShopDescription)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("shop_description");
            entity.Property(e => e.ShopImage)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("shop_image");
            entity.Property(e => e.ShopName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("shop_name");
            entity.Property(e => e.ShopOpening)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("shop_opening");
        });

        modelBuilder.Entity<WishList>(entity =>
        {
            entity.ToTable("Wish_List");

            entity.Property(e => e.WishlistId).HasColumnName("wishlist_id");
            entity.Property(e => e.AccId).HasColumnName("acc_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
