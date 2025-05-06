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
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> entity)
        {
            entity.HasKey(e => e.Cart_ID);

            entity.Property(e => e.Create_Date).IsRequired();
            entity.Property(e => e.Total_Price).HasColumnType("decimal(18,2)");

            // عند حذف المستخدم، سيتم حذف الكارت المرتبط به
            entity.HasOne(e => e.User)
                  .WithOne(u => u.ShoppingCart)
                  .HasForeignKey<ShoppingCart>(e => e.User_ID)
                  .OnDelete(DeleteBehavior.Cascade);

            // عند حذف الكارت، سيتم حذف العناصر المرتبطة به
            entity.HasMany(e => e.CartItems)
                  .WithOne(e => e.Cart)
                  .HasForeignKey(e => e.Cart_ID)
                  .OnDelete(DeleteBehavior.Cascade);  // حذف العناصر عند حذف الكارت
        }

    }


}
