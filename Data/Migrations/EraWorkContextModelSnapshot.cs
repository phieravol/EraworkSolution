﻿// <auto-generated />
using System;
using Data.EntityDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(EraWorkContext))]
    partial class EraWorkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Data.Models.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleDesc")
                        .HasMaxLength(2000)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(2000)");

                    b.HasKey("Id");

                    b.ToTable("AppRole", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("edbb02ea-b990-4bdc-8ece-3e625496755d"),
                            ConcurrencyStamp = "7fabf553-22a3-40c2-b433-877cc769608b",
                            Name = "Admin",
                            RoleDesc = "Can Custom system"
                        },
                        new
                        {
                            Id = new Guid("86bde3bb-e3cc-41d9-b8c3-98e796d63907"),
                            ConcurrencyStamp = "41c599c9-faaf-470c-abcf-389219b5bf06",
                            Name = "Provider",
                            RoleDesc = "Provide service for client"
                        },
                        new
                        {
                            Id = new Guid("d33fe90a-dba1-4f78-98f0-9a304cda119d"),
                            ConcurrencyStamp = "39ca7c76-ea78-4192-8976-9d05b65ad5c4",
                            Name = "Client",
                            RoleDesc = "Can order services from provider"
                        });
                });

            modelBuilder.Entity("Data.Models.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("MemberSince")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Local));

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserDesc")
                        .HasMaxLength(2000)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("UserLable")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("UserLevel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AppUser", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("97869d40-86bf-44e6-b5fe-da831bc70f1c"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4084cea0-8286-4f4a-96cd-625329f73bb7",
                            Email = "phinqhe153034@fpt.edu.vn",
                            EmailConfirmed = false,
                            FirstName = "Nguyễn",
                            LastName = "Quốc Phi",
                            LockoutEnabled = false,
                            MemberSince = new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Local),
                            PasswordHash = "AQAAAAEAACcQAAAAEGfX1YDDvnh7y/E8/MMtkyAndI5k7Wv0+sjaUq1HsRM4bQNfPguHt0WHEJDfYKweHw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserDesc = "Tôi là một Designer, chuyên design sự tương tư của bạn :))",
                            UserLable = "",
                            UserLevel = 1,
                            UserName = "phiphongphanh",
                            UserStatus = 1
                        });
                });

            modelBuilder.Entity("Data.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

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

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryDescription = "You think it. A programmer develops it.",
                            CategoryName = "Programing",
                            isCategoryActive = true
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryDescription = "You think it. A programmer develops it.Designs to make you stand out.",
                            CategoryName = "Graphics & Design",
                            isCategoryActive = true
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryDescription = "Bring your story to life with creative videos.",
                            CategoryName = "Video & Animation",
                            isCategoryActive = true
                        });
                });

            modelBuilder.Entity("Data.Models.OrderRequest", b =>
                {
                    b.Property<int?>("OrderRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("OrderRequestId"), 1L, 1);

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

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OrderRequestId");

                    b.HasIndex("PostId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("UserId");

                    b.ToTable("OrderRequest", (string)null);
                });

            modelBuilder.Entity("Data.Models.Pakage", b =>
                {
                    b.Property<int>("PakageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PakageId"), 1L, 1);

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("PakageDetailId"), 1L, 1);

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"), 1L, 1);

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
                        .HasDefaultValue(new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Local));

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PostId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("Data.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"), 1L, 1);

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
                        .HasDefaultValue(new DateTime(2023, 2, 13, 23, 50, 14, 255, DateTimeKind.Local).AddTicks(6573));

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int?>("Stars")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReviewId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("UserId");

                    b.ToTable("Review", (string)null);
                });

            modelBuilder.Entity("Data.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"), 1L, 1);

                    b.Property<string>("ServiceIntro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceTitle")
                        .HasMaxLength(600)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(600)");

                    b.Property<int?>("SubCategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("TotalClients")
                        .HasColumnType("int");

                    b.Property<int?>("TotalStars")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("isServiceActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("ServiceId");

                    b.HasIndex("SubCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Service", (string)null);
                });

            modelBuilder.Entity("Data.Models.SubCategory", b =>
                {
                    b.Property<int>("SubCateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubCateId"), 1L, 1);

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

                    b.HasData(
                        new
                        {
                            SubCateId = 1,
                            CategoryId = 1,
                            SubcateDesc = "Xây dựng website wordpress tại bất cứ đâu",
                            SubcateName = "Wordpress",
                            isSubCateActive = true
                        },
                        new
                        {
                            SubCateId = 2,
                            CategoryId = 1,
                            SubcateDesc = "Cùng đội ngũ freelancer xây dựng website của bạn.",
                            SubcateName = "Website development",
                            isSubCateActive = true
                        },
                        new
                        {
                            SubCateId = 3,
                            CategoryId = 1,
                            SubcateDesc = "Bảo trì hệ thống bằng đội ngũ freelancer.",
                            SubcateName = "Website maintainance",
                            isSubCateActive = true
                        },
                        new
                        {
                            SubCateId = 4,
                            CategoryId = 2,
                            SubcateDesc = "Chỉnh sửa những bức ảnh đẹp cùng đội ngũ chúng tôi.",
                            SubcateName = "Photo Design",
                            isSubCateActive = true
                        },
                        new
                        {
                            SubCateId = 5,
                            CategoryId = 2,
                            SubcateDesc = "Thiết kế đồ họa 2D theo yêu cầu của bạn",
                            SubcateName = "Design 2D",
                            isSubCateActive = true
                        },
                        new
                        {
                            SubCateId = 6,
                            CategoryId = 2,
                            SubcateDesc = "Thiết kế ý tưởng & đồ họa cho game ",
                            SubcateName = "Graphics Game",
                            isSubCateActive = false
                        },
                        new
                        {
                            SubCateId = 7,
                            CategoryId = 3,
                            SubcateDesc = "Edit video với chất lượng tuyệt vời",
                            SubcateName = "Video Edition",
                            isSubCateActive = true
                        },
                        new
                        {
                            SubCateId = 8,
                            CategoryId = 3,
                            SubcateDesc = "Làm ra thước phim hoạt hình vượt ngoài trí tưởng tượng.",
                            SubcateName = "Animation Creating",
                            isSubCateActive = true
                        },
                        new
                        {
                            SubCateId = 9,
                            CategoryId = 3,
                            SubcateDesc = "Hướng dẫn chỉnh sửa video một cách tận tình",
                            SubcateName = "Video Teaching",
                            isSubCateActive = false
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppRoleClaim", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("AppUserClaim", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserLogin", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("AppUserRole", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<Guid>");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("97869d40-86bf-44e6-b5fe-da831bc70f1c"),
                            RoleId = new Guid("edbb02ea-b990-4bdc-8ece-3e625496755d")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserToken", (string)null);
                });

            modelBuilder.Entity("Data.Models.AppUserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>");

                    b.HasIndex("RoleId");

                    b.ToTable("AppUserRole", (string)null);

                    b.HasDiscriminator().HasValue("AppUserRole");
                });

            modelBuilder.Entity("Data.Models.OrderRequest", b =>
                {
                    b.HasOne("Data.Models.Post", "Post")
                        .WithMany("OrderRequests")
                        .HasForeignKey("PostId");

                    b.HasOne("Data.Models.Service", "Service")
                        .WithMany("OrderRequests")
                        .HasForeignKey("ServiceId");

                    b.HasOne("Data.Models.AppUser", "AppUser")
                        .WithMany("OrderRequests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

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

                    b.HasOne("Data.Models.AppUser", "AppUser")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Data.Models.Review", b =>
                {
                    b.HasOne("Data.Models.Service", "Service")
                        .WithMany("Reviews")
                        .HasForeignKey("ServiceId");

                    b.HasOne("Data.Models.AppUser", "AppUser")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Data.Models.Service", b =>
                {
                    b.HasOne("Data.Models.SubCategory", "SubCategory")
                        .WithMany("Services")
                        .HasForeignKey("SubCategoryId");

                    b.HasOne("Data.Models.AppUser", "AppUser")
                        .WithMany("Services")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Data.Models.SubCategory", b =>
                {
                    b.HasOne("Data.Models.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Data.Models.AppUserRole", b =>
                {
                    b.HasOne("Data.Models.AppRole", "Role")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.AppUser", "User")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Models.AppRole", b =>
                {
                    b.Navigation("AppUserRoles");
                });

            modelBuilder.Entity("Data.Models.AppUser", b =>
                {
                    b.Navigation("AppUserRoles");

                    b.Navigation("OrderRequests");

                    b.Navigation("Posts");

                    b.Navigation("Reviews");

                    b.Navigation("Services");
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
