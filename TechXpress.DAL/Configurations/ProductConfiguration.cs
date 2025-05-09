using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TechXpress.DAL.Entities;

namespace TechXpress.DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {

            entity.HasKey(e => e.Product_ID);
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Stock).IsRequired();
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.AddTime).IsRequired();

            // عند حذف الكاتيجوري، يتم حذف البرودكتات المرتبطة بها
            entity.HasOne(e => e.Category)
                  .WithMany(e => e.Products)
                  .HasForeignKey(e => e.Category_ID)
                  .OnDelete(DeleteBehavior.Cascade); // الحذف التلقائي للمنتجات عند حذف الكاتيجوري

            // عند حذف المنتج، يتم حذف الصور المرتبطة به
            entity.HasMany(e => e.ProductImages)
                  .WithOne(e => e.Product)
                  .HasForeignKey(e => e.Product_ID)
                  .OnDelete(DeleteBehavior.Cascade); // الحذف التلقائي للصور عند حذف المنتج


            entity.HasMany(e => e.OrderDetails)
         .WithOne(e => e.Product)
         .HasForeignKey(e => e.Product_ID)
         .OnDelete(DeleteBehavior.SetNull); // تعيين NULL بدلاً من حذف السجلات المرتبطة في الأوردر

            // عند حذف المنتج، يتم حذف المراجعات المرتبطة به
            entity.HasMany(e => e.Reviews)
                  .WithOne(e => e.Product)
                  .HasForeignKey(e => e.Product_ID)
                  .OnDelete(DeleteBehavior.Cascade); // الحذف التلقائي للمراجعات عند حذف المنتج


        }

    }
    
}
