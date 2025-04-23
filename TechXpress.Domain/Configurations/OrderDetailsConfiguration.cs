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
    class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> entity)
        {
            entity.HasKey(e => new { e.Order_ID, e.Product_ID }); // Composite key

            entity.Property(e => e.Price)
                  .HasColumnType("decimal(18,2)");

            entity.Property(e => e.Quantity)
                  .IsRequired();

            entity.HasOne(e => e.Order)
                  .WithMany(o => o.OrderDetails)
                  .HasForeignKey(e => e.Order_ID);

            entity.HasOne(e => e.Product)
                  .WithMany(p => p.OrderDetails)
                  .HasForeignKey(e => e.Product_ID);
        }
    }
   
}
