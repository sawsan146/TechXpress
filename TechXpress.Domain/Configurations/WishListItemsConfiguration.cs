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
    public class WishListItemsConfiguration : IEntityTypeConfiguration<WishListItems>
    {

        
            public void Configure(EntityTypeBuilder<WishListItems> entity)
            {
                entity.HasKey(e => e.WishList_Item_ID);

                // العلاقة بين WishListItems و Product مع Cascade Delete
                entity.HasOne(e => e.Product)
                      .WithMany() // إذا كان الـ Product لا يحتوي على قائمة WishListItems (لا علاقة عكسية)
                      .HasForeignKey(e => e.Product_ID)
                      .OnDelete(DeleteBehavior.Restrict); // لا يسمح بحذف المنتج إذا كان له عناصر في الـ WishList

                // العلاقة بين WishListItems و WishList مع Cascade Delete
                entity.HasOne(e => e.WishList)
                      .WithMany(e => e.WishListItems)
                      .HasForeignKey(e => e.WishList_ID)
                      .OnDelete(DeleteBehavior.Cascade); // سيتم حذف الـ WishListItem عند حذف الـ WishList
            }
        

    }

}
