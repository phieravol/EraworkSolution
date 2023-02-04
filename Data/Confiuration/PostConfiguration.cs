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
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public readonly DateTime currentDate = DateTime.Today;

        public void Configure(EntityTypeBuilder<Post> builder)
        {
            // config table name
            builder.ToTable("Post");

            // config primary key PostId
            builder.HasKey(x => x.PostId);

            // config unicode and maxlength for post title
            builder.Property(x => x.PostTitle)
                .IsUnicode(true)
                .HasMaxLength(500);

            // post detail nvarchar(4000)
            builder.Property(x => x.PostDetails)
                .IsUnicode(true)
                .HasMaxLength(4000);

            // config default datetime for posted date
            builder.Property(x => x.PostedDate)
                .IsRequired()
                .HasDefaultValue(currentDate);

            // config reference name categoy id
            builder.HasOne(c => c.Category)
                .WithMany(p => p.Posts)
                .HasForeignKey(c => c.CategoryId);
        }
    }
}
