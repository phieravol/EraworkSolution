using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataSample
{
    public static class EraWorkDbSample
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // data sample for category
            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, CategoryName = "Programing", isCategoryActive = true, CategoryDescription = "You think it. A programmer develops it." },
                new Category() { CategoryId = 2, CategoryName = "Graphics & Design", isCategoryActive = true, CategoryDescription = "You think it. A programmer develops it.Designs to make you stand out." },
                new Category() { CategoryId = 3, CategoryName = "Video & Animation", isCategoryActive = true, CategoryDescription = "Bring your story to life with creative videos." }
                );

            // data sameple SubCategory (10ph)
            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory() { SubCateId = 1, SubcateName = "Wordpress", isSubCateActive = true, SubcateDesc = "Xây dựng website wordpress tại bất cứ đâu", CategoryId = 1 },
                new SubCategory() { SubCateId = 2, SubcateName = "Website development", isSubCateActive = true, SubcateDesc = "Cùng đội ngũ freelancer xây dựng website của bạn.", CategoryId = 1 },
                new SubCategory() { SubCateId = 3, SubcateName = "Website maintainance", isSubCateActive = true, SubcateDesc = "Bảo trì hệ thống bằng đội ngũ freelancer.", CategoryId = 1 },
                new SubCategory() { SubCateId = 4, SubcateName = "Photo Design", isSubCateActive = true, SubcateDesc = "Chỉnh sửa những bức ảnh đẹp cùng đội ngũ chúng tôi.", CategoryId = 2 },
                new SubCategory() { SubCateId = 5, SubcateName = "Design 2D", isSubCateActive = true, SubcateDesc = "Thiết kế đồ họa 2D theo yêu cầu của bạn", CategoryId = 2 },
                new SubCategory() { SubCateId = 6, SubcateName = "Graphics Game", isSubCateActive = false, SubcateDesc = "Thiết kế ý tưởng & đồ họa cho game ", CategoryId = 2 },
                new SubCategory() { SubCateId = 7, SubcateName = "Video Edition", isSubCateActive = true, SubcateDesc = "Edit video với chất lượng tuyệt vời", CategoryId = 3 },
                new SubCategory() { SubCateId = 8, SubcateName = "Animation Creating", isSubCateActive = true, SubcateDesc = "Làm ra thước phim hoạt hình vượt ngoài trí tưởng tượng.", CategoryId = 3 },
                new SubCategory() { SubCateId = 9, SubcateName = "Video Teaching", isSubCateActive = false, SubcateDesc = "Hướng dẫn chỉnh sửa video một cách tận tình", CategoryId = 3 }
                );
     
            var hasher = new PasswordHasher<AppUser>();

            // data sameple AppUser (40ph)
            modelBuilder.Entity<AppRole>().HasData(new AppRole()
            {
                Id = new Guid("1DEE62EE-AE2C-4417-A65C-74E992B1CA32"),
                Name = "Admin",
                RoleDesc = "Can Custom system"
            });

            modelBuilder.Entity<AppRole>().HasData(new AppRole()
            {
                Id = new Guid("BD839B07-BEAC-492E-8688-E3522A60476E"),

				Name = "Provider",
                RoleDesc = "Provide service for client"
            });
            modelBuilder.Entity<AppRole>().HasData(new AppRole()
            {
                Id = new Guid("6859DC0F-5F7D-47E1-B35D-BD45ACF3F3C8"),
                Name = "Client",
                RoleDesc = "Can order services from provider"
            });

            modelBuilder.Entity<AppUser>().HasData(new AppUser()
            {
                Id = new Guid("A27ED6DA-8F70-4A41-82CD-2FB50DABEB18"),
                FirstName = "Nguyễn",
                LastName = "Quốc Phi",
                UserName = "phinq",
                UserStatus = 1,
                UserLevel = "Other",
                UserDesc = "Tôi là một Designer, chuyên design sự tương tư của bạn :))",
                UserLable = "",
                MemberSince = DateTime.Today,
                Email = "phinqhe153034@fpt.edu.vn",
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "SOME_ADMIN_PLAIN_PASSWORD"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId= new Guid("1DEE62EE-AE2C-4417-A65C-74E992B1CA32"),
                UserId= new Guid("A27ED6DA-8F70-4A41-82CD-2FB50DABEB18"),
            });
        }
    }
}
