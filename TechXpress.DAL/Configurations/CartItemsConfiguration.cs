using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TechXpress.DAL.Configurations
  
{
    public class CartItemsConfiguration : IEntityTypeConfiguration<CartItems>
    {
        public void Configure(EntityTypeBuilder<CartItems> entity)
        {
            entity.HasKey(e => e.Cart_Item_ID);
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Quantity).IsRequired();
            entity.Property(e => e.AdditionTime).IsRequired();

            // تعديل العلاقة بين CartItems و Product
            entity.HasOne(e => e.Product)
                  .WithMany(e => e.CartItems)
                  .HasForeignKey(e => e.Product_ID)
                  .OnDelete(DeleteBehavior.Restrict);  // لا نريد حذف المنتج نفسه

            // تعديل العلاقة بين CartItems و Cart
            entity.HasOne(e => e.Cart)
                  .WithMany(c => c.CartItems)
                  .HasForeignKey(e => e.Cart_ID)
                  .OnDelete(DeleteBehavior.Cascade);  // حذف الكارت عند حذف المستخدم
        }

    }


}
