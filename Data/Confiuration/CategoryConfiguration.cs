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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public readonly bool ActiveCategory = true;
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //config table name
            builder.ToTable("Category");

            //config primary key for category id
            builder.HasKey(x => x.CategoryId);

            //config category name is nvarchar(150)
            builder.Property(x => x.CategoryName)
                .IsUnicode(true)
                .HasMaxLength(150);

            //Category Desc is nvarchar(500)
            builder.Property(x => x.CategoryDescription)
                .IsUnicode(true)
                .HasMaxLength(500);

            //config default value for category is true
            builder.Property(x => x.isCategoryActive)
                .HasDefaultValue(ActiveCategory);
        }
    }
}
