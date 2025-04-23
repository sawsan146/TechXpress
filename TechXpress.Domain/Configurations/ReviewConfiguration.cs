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
    class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> entity)
        {
            entity.HasKey(e => e.Review_ID);
            entity.Property(e => e.Rating).IsRequired();
            entity.Property(e => e.Comment).HasMaxLength(1000);
            entity.Property(e => e.ReviewDate).IsRequired();

            entity.HasOne(e => e.User).WithMany(e => e.Reviews).HasForeignKey(e => e.User_ID);
            entity.HasOne(e => e.Product).WithMany(e => e.Reviews).HasForeignKey(e => e.Product_ID);
        }
    }

   
}
