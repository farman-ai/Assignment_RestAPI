using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Entities;

namespace Order.Infrastructure.Data;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
    }

    public DbSet<OrderHistory> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderHistory>(entity =>
        {
            entity.ToTable("Order");
            entity.HasKey(o => o.Id);
            entity.Property(o => o.BillAmount).HasPrecision(18, 2);
            entity.Property(o => o.CustomerName).HasMaxLength(100).IsRequired();
            entity.Property(o => o.PaymentName).HasMaxLength(100).IsRequired();
            entity.Property(o => o.ShippingAddress).HasMaxLength(500).IsRequired();
            entity.Property(o => o.ShippingMethod).HasMaxLength(100).IsRequired();
            entity.Property(o => o.Order_Status).HasMaxLength(50).IsRequired();
        });

        modelBuilder.Entity<OrderDetails>(entity =>
        {
            entity.ToTable("Order_Details");
            entity.HasKey(od => od.Id);
            entity.Property(od => od.Product_name).HasMaxLength(200).IsRequired();
            entity.Property(od => od.Price).HasPrecision(18, 2);
            entity.Property(od => od.Discount).HasPrecision(18, 2);

            entity.HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.Order_Id)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
