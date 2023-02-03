using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Confiuration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        private readonly DateTime reviewTime = DateTime.Now; 
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            // config table name for Review
            builder.ToTable("Review");

            // config primary key for ReivewId
            builder.HasKey(e => e.ReviewId);

            //config comment is nvarchar(1000)
            builder.Property(e => e.Comment)
                .IsUnicode(true)
                .HasMaxLength(1000);

            //config default time is now
            builder.Property(e => e.ReviewTime)
                .IsRequired()
                .HasDefaultValue(reviewTime);

            // config reference key for Service Id
            builder.HasOne(s => s.Service)
                .WithMany(r => r.Reviews)
                .HasForeignKey(s => s.ServiceId);
        }
    }
}
