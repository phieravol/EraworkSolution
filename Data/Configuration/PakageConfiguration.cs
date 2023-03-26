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
    public class PakageConfiguration : IEntityTypeConfiguration<Pakage>
    {
        public readonly bool ActivePakageDefault = true;
        public void Configure(EntityTypeBuilder<Pakage> builder)
        {
            // config for table name Pakage
            builder.ToTable("Pakage");

            // config for primary key PakageId
            builder.HasKey(x => x.PakageId);

            // config pakage name is nvarchar(100)
            builder.Property(x => x.PakageName)
                .IsUnicode(true)
                .HasMaxLength(100);

            //config price money for pakage
            builder.Property(x => x.Price)
                .IsRequired();
               
            //config for revision limit is nvarchar(500)
            builder.Property(x => x.RevisionLimit)
                .IsUnicode(true)
                .HasMaxLength(250);
            // config default value for isPakageActive
            builder.Property(x => x.isPakageAcive)
                .IsRequired()
                .HasDefaultValue(ActivePakageDefault);

            // config reference key for Service Id
            builder.HasOne(s => s.Service)
                .WithMany(p => p.Pakages)
                .HasForeignKey(s => s.ServiceId);


        }
    }
}
