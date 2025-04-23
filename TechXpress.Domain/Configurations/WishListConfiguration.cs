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
    class WishListConfiguration : IEntityTypeConfiguration<WishList>
    {
        public void Configure(EntityTypeBuilder<WishList> entity)
        {
            entity.HasKey(e => e.WishList_ID);
            entity.HasOne(e => e.User).WithMany(e => e.WishLists).HasForeignKey(e => e.User_ID);
            entity.HasMany(e => e.WishListItems).WithOne(e => e.WishList).HasForeignKey(e => e.WishList_ID);
        }
    }
   
}
