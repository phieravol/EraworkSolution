using Data.Models;
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
                ) ;

            // data sameple OrderRequest
            

            // data sameple Pakage

            // data sameple PakageDetail

            // data sameple Post (10ph)
            modelBuilder.Entity<Post>().HasData(
                new Post() { PostId = 1, PostTitle="Tôi cần tìm một c# backend developer để phát triển website", PostDetails="Thông thạo ASP.NET core, EntityFrameWork, Restful API", Budget=1000, ExpirationDate= new DateTime(2023, 10, 23, 0, 0, 0),PostedDate= DateTime.Today, CategoryId=1},
                new Post() { PostId = 2, PostTitle="Tôi cần tìm một Wordpress dev để phát triển theme", PostDetails="Có kỹ năng sử dụng CSS, JQuery, React & Bootstrap", Budget=300, ExpirationDate = new DateTime(2023, 5, 10, 0, 0, 0), PostedDate = DateTime.Today, CategoryId = 1 },
                new Post() { PostId = 3, PostTitle="Tôi cần bảo trì giao diện cho trang web", PostDetails="Trang web của tôi đang bị lỗi giao diện, tôi có thể trả bạn số tiền phù hợp với những gì bạn đã đóng góp cho chúng tôi", Budget=3000, ExpirationDate = new DateTime(2023, 6, 9, 0, 0, 0), PostedDate = DateTime.Today, CategoryId = 1 },
                new Post() { PostId = 4, PostTitle="Tôi cần designer có thể chỉnh sửa ảnh cưới cho chúng tôi", Budget=200, ExpirationDate = new DateTime(2023, 6, 10, 0, 0, 0), PostedDate = DateTime.Today, CategoryId = 2 },
                new Post() { PostId = 5, PostTitle="Tôi cần editor có thể chỉnh sửa video cho chúng tôi", Budget=900, ExpirationDate = new DateTime(2023, 8, 11, 0, 0, 0), PostedDate = DateTime.Today, CategoryId = 3 }
                
                );

            // data sameple Review

            // data sameple Service
                //modelBuilder.Entity<Service>().HasData(
                //    new Service() { ServiceId = 1, ServiceTitle="Tôi có thể Thiết kế giao diện với mọi trang web mà bạn cần", Stars=0, Comment}
                //);

            // data sameple SubCategory (10ph)
            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory() { SubCateId=1, SubcateName="Wordpress", isSubCateActive=true, SubcateDesc="Xây dựng website wordpress tại bất cứ đâu", CategoryId=1},
                new SubCategory() { SubCateId=2, SubcateName="Website development", isSubCateActive=true, SubcateDesc="Cùng đội ngũ freelancer xây dựng website của bạn.", CategoryId=1},
                new SubCategory() { SubCateId=3, SubcateName="Website maintainance", isSubCateActive=true, SubcateDesc="Bảo trì hệ thống bằng đội ngũ freelancer.", CategoryId=1},
                new SubCategory() { SubCateId=4, SubcateName="Photo Design", isSubCateActive=true, SubcateDesc="Chỉnh sửa những bức ảnh đẹp cùng đội ngũ chúng tôi.", CategoryId=2},
                new SubCategory() { SubCateId=5, SubcateName="Design 2D", isSubCateActive=true, SubcateDesc="Thiết kế đồ họa 2D theo yêu cầu của bạn", CategoryId=2},
                new SubCategory() { SubCateId=6, SubcateName="Graphics Game", isSubCateActive=false, SubcateDesc="Thiết kế ý tưởng & đồ họa cho game ", CategoryId=2},
                new SubCategory() { SubCateId=7, SubcateName="Video Edition", isSubCateActive=true, SubcateDesc="Edit video với chất lượng tuyệt vời", CategoryId=3},
                new SubCategory() { SubCateId=8, SubcateName="Animation Creating", isSubCateActive=true, SubcateDesc="Làm ra thước phim hoạt hình vượt ngoài trí tưởng tượng.", CategoryId=3},
                new SubCategory() { SubCateId=9, SubcateName="Video Teaching", isSubCateActive=false, SubcateDesc="Hướng dẫn chỉnh sửa video một cách tận tình", CategoryId=3}
                );

            //modelBuilder.En
        }
    }
}
