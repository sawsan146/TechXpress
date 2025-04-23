using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TechXpress.Domain.Entities;
using System.Reflection.Emit;

namespace TechXpress.Domain.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.User_ID);
            entity.Property(e => e.User_Type).IsRequired();
            entity.Property(e => e.Fname).HasMaxLength(50);
            entity.Property(e => e.Lname).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.Password).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Country).HasMaxLength(50);

            entity.HasMany(e => e.Orders).WithOne(e => e.User).HasForeignKey(e => e.User_ID);
            entity.HasMany(e => e.Returns).WithOne(e => e.User).HasForeignKey(e => e.User_ID);
            entity.HasMany(e => e.Reviews).WithOne(e => e.User).HasForeignKey(e => e.User_ID);
            entity.HasOne(u => u.ShoppingCart).WithOne(c => c.User).HasForeignKey<ShoppingCart>(c => c.User_ID);
            entity.HasMany(e => e.WishLists).WithOne(e => e.User).HasForeignKey(e => e.User_ID);
        }
    }
    
}
