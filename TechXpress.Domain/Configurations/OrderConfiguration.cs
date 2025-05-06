using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TechXpress.Domain.Entities;

namespace TechXpress.Domain.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.HasKey(e => e.Order_ID);

            entity.Property(e => e.CreationTime)
                  .IsRequired();

            entity.Property(e => e.ShippingGoal)
                  .IsRequired();

            entity.Property(e => e.DeliveryDate)
                  .IsRequired();

            entity.Property(e => e.Status)
                  .IsRequired();

            entity.Property(e => e.TotalAmount)
                  .HasColumnType("decimal(18,2)");

            // العلاقة بين Order و User مع حذف تلقائي للطلبات عند حذف المستخدم
            entity.HasOne(o => o.User)
                  .WithMany(u => u.Orders)
                  .HasForeignKey(o => o.User_ID)
                  .OnDelete(DeleteBehavior.SetNull); // حذف تلقائي للطلب عند حذف المستخدم

            // العلاقة بين Order و OrderDetails مع الحذف التلقائي
            entity.HasMany(o => o.OrderDetails)
                  .WithOne(od => od.Order)
                  .HasForeignKey(od => od.Order_ID)
                  .OnDelete(DeleteBehavior.Cascade); // حذف تلقائي للتفاصيل عند حذف الطلب

            // العلاقة بين Order و Payment مع الحذف التلقائي
            entity.HasOne(o => o.Payment)
                  .WithOne(p => p.Order)
                  .HasForeignKey<Payment>(p => p.Order_ID)
                  .OnDelete(DeleteBehavior.Cascade); // حذف تلقائي للدفع عند حذف الطلب
        }

    }

}
