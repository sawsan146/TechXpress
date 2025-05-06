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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasKey(e => e.Category_ID);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);

            // العلاقة بين Category و Products مع الحذف التلقائي للمنتجات عند حذف الفئة
            entity.HasMany(e => e.Products)
                  .WithOne(e => e.Category)
                  .HasForeignKey(e => e.Category_ID)
                  .OnDelete(DeleteBehavior.Cascade); 
        }

    }

}
