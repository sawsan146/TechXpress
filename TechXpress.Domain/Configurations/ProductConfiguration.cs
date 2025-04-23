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
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(e => e.Product_ID);
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Stock).IsRequired();
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.AddTime).IsRequired();

            entity.HasOne(e => e.Category).WithMany(e => e.Products).HasForeignKey(e => e.Category_ID);
            entity.HasMany(e => e.ProductImages).WithOne(e => e.Product).HasForeignKey(e => e.Product_ID);
            entity.HasMany(e => e.OrderDetails).WithOne(e => e.Product).HasForeignKey(e => e.Product_ID);
            entity.HasMany(e => e.Reviews).WithOne(e => e.Product).HasForeignKey(e => e.Product_ID);
        }
    }
    
}
