using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Data.Confiuration
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        private readonly bool ActiveSubCate = true;
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            // Config table name SubCategory
            builder.ToTable("SubCategory");

            // Config primary key for SubCategoryId
            builder.HasKey(x => x.SubCateId);

            // config subcategory is nvarchar(250)
            builder.Property(x => x.SubcateName)
                .IsUnicode(true)
                .HasMaxLength(250);

            // config subcategory desc is nvarchar(1000)
            builder.Property(x => x.SubcateDesc)
                .IsUnicode(true)
                .HasMaxLength(1000);

            // Config default value for isSubCateActive
            builder.Property(x => x.isSubCateActive)
                .IsRequired()
                .HasDefaultValue(ActiveSubCate);

            // Config reference key for CategoryId
            builder.HasOne(c => c.Category)
                .WithMany(s => s.SubCategories)
                .HasForeignKey(c => c.CategoryId);
        }

    }
}

