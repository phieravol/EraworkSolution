using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.Confiuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            //config table name AppUser
            builder.ToTable("AppUser");

            //config fullname is nvarchar(100)
            builder.Property(x => x.FullName)
                .IsUnicode(true)
                .HasMaxLength(100);

            //config user desc is nvarchar(2000)
            builder.Property(x => x.UserDesc)
                .IsUnicode(true)
                .HasMaxLength(2000);

            //config member since is now
            builder.Property(x => x.MemberSince)
                .IsRequired(true)
                .HasDefaultValue(DateTime.Today);
        }
    }
}
