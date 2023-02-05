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
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        private readonly bool ActiveService = true;
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            // config table name Service
            builder.ToTable("Service");

            // config primary key ServiceId
            builder.HasKey(x => x.ServiceId);

            // config service title nvarchar(600)
            builder.Property(x => x.ServiceTitle)
                .IsUnicode(true)
                .HasMaxLength(600);

            // config default value for isActiveService
            builder.Property(x => x.isServiceActive)
                .IsRequired()
                .HasDefaultValue(ActiveService);

            // Config reference key for SubCategoryId
            builder.HasOne(sub => sub.SubCategory)
                .WithMany(ser => ser.Services)
                .HasForeignKey(x => x.SubCategoryId);
        }
    }
}
