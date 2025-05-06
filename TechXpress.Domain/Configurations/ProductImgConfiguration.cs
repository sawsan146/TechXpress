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
    public class ProductImgConfiguration : IEntityTypeConfiguration<ProductImg>
    {
        public void Configure(EntityTypeBuilder<ProductImg> entity)
        {
            entity.HasKey(e => e.Image_ID);
            entity.Property(e => e.ImageURL).IsRequired();

            // عند حذف المنتج، يتم حذف الصور المرتبطة به
            entity.HasOne(e => e.Product)
                  .WithMany(e => e.ProductImages)
                  .HasForeignKey(e => e.Product_ID)
                  .OnDelete(DeleteBehavior.Cascade); // الحذف التلقائي للصور عند حذف المنتج
        }

    }

}
