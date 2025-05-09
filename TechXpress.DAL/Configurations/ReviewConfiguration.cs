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
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> entity)
        {
            entity.HasKey(e => e.Review_ID);
            entity.Property(e => e.Rating).IsRequired();
            entity.Property(e => e.Comment).HasMaxLength(1000);
            entity.Property(e => e.ReviewDate).IsRequired();

            // عند حذف المستخدم، يتم حذف المراجعات المرتبطة به
            entity.HasOne(e => e.User)
                  .WithMany(e => e.Reviews)
                  .HasForeignKey(e => e.User_ID)
                  .OnDelete(DeleteBehavior.Cascade);  // حذف المراجعات عند حذف المستخدم

            // عند حذف المنتج، يتم حذف المراجعات المرتبطة به
            entity.HasOne(e => e.Product)
                  .WithMany(e => e.Reviews)
                  .HasForeignKey(e => e.Product_ID)
                  .OnDelete(DeleteBehavior.Cascade);  // حذف المراجعات عند حذف المنتج
        }

    }


}
