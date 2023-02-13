using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Confiuration
{
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.ToTable("AppUserRole");
            builder.HasOne(u => u.User).WithMany(ur => ur.AppUserRoles).HasForeignKey(r => r.UserId);
            builder.HasOne(r => r.Role)
                .WithMany(ur => ur.AppUserRoles)
                .HasForeignKey(r => r.RoleId);
        }
    }
}
