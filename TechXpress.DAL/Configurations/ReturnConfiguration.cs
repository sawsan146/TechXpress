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
    public class ReturnConfiguration : IEntityTypeConfiguration<Return>
    {
        public void Configure(EntityTypeBuilder<Return> entity)
        {
            entity.HasKey(e => e.Return_ID);
            entity.Property(e => e.Reason).HasMaxLength(500);
            entity.Property(e => e.ReturnDate).IsRequired();
            entity.Property(e => e.Status).IsRequired();

            // عند حذف المستخدم، تعيين NULL في User_ID بدلاً من الحذف
            entity.HasOne(e => e.User)
                  .WithMany(e => e.Returns)
                  .HasForeignKey(e => e.User_ID)
                  .OnDelete(DeleteBehavior.SetNull);

            // عند حذف الطلب، تعيين NULL في Order_ID بدلاً من الحذف
            entity.HasOne(e => e.Order)
                  .WithMany()
                  .HasForeignKey(e => e.Order_ID)
                  .OnDelete(DeleteBehavior.SetNull);  // الحذف هنا يكون SetNull بدلاً من الحذف التلقائي
        }

    }

}
