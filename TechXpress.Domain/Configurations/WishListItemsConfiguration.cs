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
    class WishListItemsConfiguration : IEntityTypeConfiguration<WishListItems>
    {
        public void Configure(EntityTypeBuilder<WishListItems> entity)
        {
            entity.HasKey(e => e.WishList_Item_ID);
            entity.HasOne(e => e.Product).WithMany().HasForeignKey(e => e.Product_ID);
            entity.HasOne(e => e.WishList).WithMany(e => e.WishListItems).HasForeignKey(e => e.WishList_ID);
        }
    }
   
}
