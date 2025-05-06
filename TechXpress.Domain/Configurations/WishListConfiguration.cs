using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechXpress.Domain.Entities;

public class WishListConfiguration : IEntityTypeConfiguration<WishList>
{
    public void Configure(EntityTypeBuilder<WishList> entity)
    {
        entity.HasKey(e => e.WishList_ID);

        // إضافة DeleteBehavior.Cascade لحذف الـ WishList عند حذف المستخدم
        entity.HasOne(e => e.User)
            .WithOne(u => u.WishList)
            .HasForeignKey<WishList>(e => e.User_ID)
            .OnDelete(DeleteBehavior.Cascade);  // سلوك الحذف التلقائي للمستخدم

        entity.HasMany(e => e.WishListItems)
            .WithOne(e => e.WishList)
            .HasForeignKey(e => e.WishList_ID);
    }
}


