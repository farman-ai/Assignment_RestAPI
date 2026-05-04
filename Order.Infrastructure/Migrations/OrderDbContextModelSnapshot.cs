using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Order.Infrastructure.Data;

#nullable disable

namespace Order.Infrastructure.Migrations;

[DbContext(typeof(OrderDbContext))]
public class OrderDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasAnnotation("ProductVersion", "10.0.7")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

        modelBuilder.Entity("Order.ApplicationCore.Entities.OrderDetails", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

            b.Property<decimal>("Discount")
                .HasPrecision(18, 2)
                .HasColumnType("decimal(18,2)");

            b.Property<int>("Order_Id")
                .HasColumnType("int");

            b.Property<decimal>("Price")
                .HasPrecision(18, 2)
                .HasColumnType("decimal(18,2)");

            b.Property<int>("Product_Id")
                .HasColumnType("int");

            b.Property<string>("Product_name")
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("nvarchar(200)");

            b.Property<int>("Qty")
                .HasColumnType("int");

            b.HasKey("Id");

            b.HasIndex("Order_Id");

            b.ToTable("Order_Details");
        });

        modelBuilder.Entity("Order.ApplicationCore.Entities.OrderHistory", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

            b.Property<decimal>("BillAmount")
                .HasPrecision(18, 2)
                .HasColumnType("decimal(18,2)");

            b.Property<int>("CustomerId")
                .HasColumnType("int");

            b.Property<string>("CustomerName")
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");

            b.Property<DateTime>("Order_Date")
                .HasColumnType("datetime2");

            b.Property<string>("Order_Status")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");

            b.Property<int>("PaymentMethodId")
                .HasColumnType("int");

            b.Property<string>("PaymentName")
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");

            b.Property<string>("ShippingAddress")
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("nvarchar(500)");

            b.Property<string>("ShippingMethod")
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");

            b.HasKey("Id");

            b.ToTable("Order");
        });

        modelBuilder.Entity("Order.ApplicationCore.Entities.OrderDetails", b =>
        {
            b.HasOne("Order.ApplicationCore.Entities.OrderHistory", "Order")
                .WithMany("OrderDetails")
                .HasForeignKey("Order_Id")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.Navigation("Order");
        });

        modelBuilder.Entity("Order.ApplicationCore.Entities.OrderHistory", b =>
        {
            b.Navigation("OrderDetails");
        });
    }
}
