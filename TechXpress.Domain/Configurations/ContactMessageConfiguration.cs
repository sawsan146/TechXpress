using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Domain.Entities;

namespace TechXpress.Domain.Configurations
{
    public class ContactMessageConfiguration : IEntityTypeConfiguration<ContactMessage>
    {
        public void Configure(EntityTypeBuilder<ContactMessage> builder)
        {
            builder.Property(cm => cm.Name)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(cm => cm.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(cm => cm.Phone)
                .HasMaxLength(20);

            builder.Property(cm => cm.Message)
                .IsRequired();

            builder.Property(cm => cm.SentAt)
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(cm => cm.User)
                .WithMany(u => u.ContactMessages)
                .HasForeignKey(cm => cm.UserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }

}

