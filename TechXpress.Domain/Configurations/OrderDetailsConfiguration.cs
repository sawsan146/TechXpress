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
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> entity)
        {
            entity.HasKey(e => new { e.Order_ID, e.Product_ID }); // Composite key

            entity.Property(e => e.Price)
                  .HasColumnType("decimal(18,2)");

            entity.Property(e => e.Quantity)
                  .IsRequired();

          // د حذف تلقائي عند حذف الطلب
            entity.HasOne(e => e.Order)
                  .WithMany(o => o.OrderDetails)
                  .HasForeignKey(e => e.Order_ID)
                  .OnDelete(DeleteBehavior.Cascade); // حذف تلقائي للتفاصيل عند حذف الطلب

            // العلاقة بين OrderDetails و Product مع تعيين القيمة NULL بدلاً من الحذف عند حذف المنتج
            entity.HasOne(e => e.Product)
                  .WithMany(p => p.OrderDetails)
                  .HasForeignKey(e => e.Product_ID)
                  .OnDelete(DeleteBehavior.Restrict); // تعيين NULL بدلاً من الحذف عند حذف المنتج
        }


    }

}
