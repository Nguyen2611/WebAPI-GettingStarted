using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_FirstPrj.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext (DbContextOptions options): base(options)
        {

        }

        #region DbSet
        public DbSet<Items> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        #endregion
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Orders");
                e.HasKey(order => order.invoiceID);
                //câu lệnh getutcdate() trả về giờ hieenjt ại theo múi giờ số 0
                e.Property(order => order.orderDate).HasDefaultValueSql("getutcdate()");
                e.Property(order => order.buyerName).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetails");
                //sử dụng anonyous object để tạo bảng có 2 khóa
                entity.HasKey(e => new { e.invoiceID, e.ISBN });

                entity.HasOne(e => e.order)
                      .WithMany(e => e.orderDetails)
                      .HasForeignKey(e => e.invoiceID)
                      .HasConstraintName("FK_OrderDetail_Order");
                entity.HasOne(e => e.item)
                      .WithMany(e => e.orderDetails)
                      .HasForeignKey(e => e.ISBN)
                      .HasConstraintName("FK_OrderDeatail_Item");
            });
        }
    }
}
