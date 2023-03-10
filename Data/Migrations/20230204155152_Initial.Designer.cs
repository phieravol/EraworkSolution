// <auto-generated />
using System;
using Data.EntityDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(EraWorkContext))]
    [Migration("20230204155152_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryDescription")
                        .HasMaxLength(500)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(500)");

                    b.Property<byte[]>("CategoryImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("CategoryName")
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool?>("isCategoryActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Data.Models.OrderRequest", b =>
                {
                    b.Property<int?>("OrderRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("OrderRequestId"));

                    b.Property<int?>("IsApprove")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int?>("PakageId")
                        .HasColumnType("int");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("RequestIntro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderRequestId");

                    b.HasIndex("PostId");

                    b.HasIndex("ServiceId");

                    b.ToTable("OrderRequest", (string)null);
                });

            modelBuilder.Entity("Data.Models.Pakage", b =>
                {
                    b.Property<int>("PakageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PakageId"));

                    b.Property<int?>("DeliveryDays")
                        .HasColumnType("int");

                    b.Property<string>("PakageName")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RevisionLimit")
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<bool?>("isPakageAcive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("PakageId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Pakage", (string)null);
                });

            modelBuilder.Entity("Data.Models.PakageDetail", b =>
                {
                    b.Property<int?>("PakageDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("PakageDetailId"));

                    b.Property<bool?>("IsDetailActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("PakageDetailDesc")
                        .HasMaxLength(500)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("PakageId")
                        .HasColumnType("int");

                    b.HasKey("PakageDetailId");

                    b.HasIndex("PakageId");

                    b.ToTable("PakageDetail", (string)null);
                });

            modelBuilder.Entity("Data.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"));

                    b.Property<decimal?>("Budget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostDetails")
                        .HasMaxLength(4000)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("PostTitle")
                        .HasMaxLength(500)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("PostedDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Local));

                    b.HasKey("PostId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("Data.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"));

                    b.Property<string>("Comment")
                        .HasMaxLength(1000)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool?>("IsHelpfull")
                        .HasColumnType("bit");

                    b.Property<int?>("Liked")
                        .HasColumnType("int");

                    b.Property<int?>("Report")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReviewTime")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 2, 4, 22, 51, 52, 3, DateTimeKind.Local).AddTicks(2924));

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int?>("Stars")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Review", (string)null);
                });

            modelBuilder.Entity("Data.Models.Service", b =>
                {
                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsHelpfull")
                        .HasColumnType("bit");

                    b.Property<int?>("Liked")
                        .HasColumnType("int");

                    b.Property<int?>("Report")
                        .HasColumnType("int");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReviewTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ServiceTitle")
                        .IsRequired()
                        .HasMaxLength(600)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(600)");

                    b.Property<int?>("Stars")
                        .HasColumnType("int");

                    b.Property<bool>("isServiceActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("ServiceId");

                    b.ToTable("Service", (string)null);
                });

            modelBuilder.Entity("Data.Models.SubCategory", b =>
                {
                    b.Property<int>("SubCateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubCateId"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("SubcateDesc")
                        .HasMaxLength(1000)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<byte[]>("SubcateImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SubcateName")
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool?>("isSubCateActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("SubCateId");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategory", (string)null);
                });

            modelBuilder.Entity("Data.Models.OrderRequest", b =>
                {
                    b.HasOne("Data.Models.Post", "Post")
                        .WithMany("OrderRequests")
                        .HasForeignKey("PostId");

                    b.HasOne("Data.Models.Service", "Service")
                        .WithMany("OrderRequests")
                        .HasForeignKey("ServiceId");

                    b.Navigation("Post");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Data.Models.Pakage", b =>
                {
                    b.HasOne("Data.Models.Service", "Service")
                        .WithMany("Pakages")
                        .HasForeignKey("ServiceId");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Data.Models.PakageDetail", b =>
                {
                    b.HasOne("Data.Models.Pakage", "Pakage")
                        .WithMany("PakageDetails")
                        .HasForeignKey("PakageId");

                    b.Navigation("Pakage");
                });

            modelBuilder.Entity("Data.Models.Post", b =>
                {
                    b.HasOne("Data.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Data.Models.Review", b =>
                {
                    b.HasOne("Data.Models.Service", "Service")
                        .WithMany("Reviews")
                        .HasForeignKey("ServiceId");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Data.Models.Service", b =>
                {
                    b.HasOne("Data.Models.SubCategory", "SubCategory")
                        .WithMany("Services")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Data.Models.SubCategory", b =>
                {
                    b.HasOne("Data.Models.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Data.Models.Category", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Data.Models.Pakage", b =>
                {
                    b.Navigation("PakageDetails");
                });

            modelBuilder.Entity("Data.Models.Post", b =>
                {
                    b.Navigation("OrderRequests");
                });

            modelBuilder.Entity("Data.Models.Service", b =>
                {
                    b.Navigation("OrderRequests");

                    b.Navigation("Pakages");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Data.Models.SubCategory", b =>
                {
                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}
