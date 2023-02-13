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
    public class PakageDetailConfiguration : IEntityTypeConfiguration<PakageDetail>
    {
        public readonly bool AciveDefault = true;

        public void Configure(EntityTypeBuilder<PakageDetail> builder)
        {
            // config table name PakageDetails
            builder.ToTable("PakageDetail");

            // config primary key for PakageDetailId
            builder.HasKey(x => x.PakageDetailId);

            //config pakagename is nvarchar(50)
            builder.Property(x => x.PakageDetailDesc)
                .IsUnicode(true)
                .HasMaxLength(500);

            // config default value for is isDetailActive
            builder.Property(x => x.IsDetailActive)
                .IsRequired()
                .HasDefaultValue(AciveDefault);

            // config reference key for PakageId
            builder.HasOne(p => p.Pakage)
                .WithMany(pd => pd.PakageDetails)
                .HasForeignKey(p => p.PakageId);
        }
    }
}
