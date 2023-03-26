using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Confiuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUser");
            builder.Property(x => x.FirstName)
                .IsUnicode(true)
                .HasMaxLength(100);
            builder.Property(x => x.LastName)
                .IsUnicode(true)
                .HasMaxLength(100);
            builder.Property(x=>x.UserLable)
                .IsUnicode(true)
                .HasMaxLength(100);
            builder.Property(x => x.UserDesc)
                .IsUnicode(true)
                .HasMaxLength(2000);
            builder.Property(x => x.MemberSince)
                .IsRequired()
                .HasDefaultValue(DateTime.Today);
            builder.Property(x => x.UserLevel)
                .IsRequired(false)
                .HasDefaultValue("beginer");
            
        }
    }
}
