using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TechXpress.DAL.Entities;
using System.Reflection.Emit;

namespace TechXpress.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.User_ID);
            entity.Property(e => e.User_Type).IsRequired();
            entity.Property(e => e.Fname).HasMaxLength(50);
            entity.Property(e => e.Lname).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Country).HasMaxLength(50);

            // استخدام DeleteBehavior.Cascade لحذف الكيانات المرتبطة عند حذف المستخدم
            entity.HasMany(e => e.Orders)
                  .WithOne(e => e.User)
                  .HasForeignKey(e => e.User_ID)
                  .OnDelete(DeleteBehavior.Cascade);  // الحذف التلقائي للطلبات عند حذف المستخدم

            entity.HasMany(e => e.Returns)
                  .WithOne(e => e.User)
                  .HasForeignKey(e => e.User_ID)
                  .OnDelete(DeleteBehavior.Cascade);  // الحذف التلقائي للـ Returns عند حذف المستخدم

            entity.HasMany(e => e.Reviews)
                  .WithOne(e => e.User)
                  .HasForeignKey(e => e.User_ID)
                  .OnDelete(DeleteBehavior.Cascade);  // الحذف التلقائي للمراجعات عند حذف المستخدم

            // العلاقة مع الـ ShoppingCart و WishList
            entity.HasOne(u => u.ShoppingCart)
                  .WithOne(c => c.User)
                  .HasForeignKey<ShoppingCart>(c => c.User_ID)
                  .OnDelete(DeleteBehavior.Cascade);  // الحذف التلقائي للعربة عند حذف المستخدم

            entity.HasOne(u => u.WishList)
                  .WithOne(w => w.User)
                  .HasForeignKey<WishList>(w => w.User_ID)
                  .OnDelete(DeleteBehavior.Cascade);  // الحذف التلقائي لقائمة الرغبات عند حذف المستخدم
        }


    }

}
