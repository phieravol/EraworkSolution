using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddBasicDataSameple : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 6, 18, 39, 43, 154, DateTimeKind.Local).AddTicks(6416),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 6, 18, 16, 41, 158, DateTimeKind.Local).AddTicks(6004));

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryImage", "CategoryName", "isCategoryActive" },
                values: new object[] { 1, "You think it. A programmer develops it.", null, "Programing", true });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryImage", "CategoryName", "isCategoryActive" },
                values: new object[] { 2, "You think it. A programmer develops it.Designs to make you stand out.", null, "Graphics & Design", true });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryImage", "CategoryName", "isCategoryActive" },
                values: new object[] { 3, "Bring your story to life with creative videos.", null, "Video & Animation", true });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "PostId", "Budget", "CategoryId", "ExpirationDate", "PostDetails", "PostTitle", "PostedDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1000m, 1, new DateTime(2023, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thông thạo ASP.NET core, EntityFrameWork, Restful API", "Tôi cần tìm một c# backend developer để phát triển website", new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Local), new Guid("00000000-0000-0000-0000-000000000000") },
                    { 2, 300m, 1, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Có kỹ năng sử dụng CSS, JQuery, React & Bootstrap", "Tôi cần tìm một Wordpress dev để phát triển theme", new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Local), new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, 3000m, 1, new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trang web của tôi đang bị lỗi giao diện, tôi có thể trả bạn số tiền phù hợp với những gì bạn đã đóng góp cho chúng tôi", "Tôi cần bảo trì giao diện cho trang web", new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Local), new Guid("00000000-0000-0000-0000-000000000000") },
                    { 4, 200m, 2, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tôi cần designer có thể chỉnh sửa ảnh cưới cho chúng tôi", new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Local), new Guid("00000000-0000-0000-0000-000000000000") },
                    { 5, 900m, 3, new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tôi cần editor có thể chỉnh sửa video cho chúng tôi", new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Local), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "SubCateId", "CategoryId", "SubcateDesc", "SubcateImage", "SubcateName", "isSubCateActive" },
                values: new object[,]
                {
                    { 1, 1, "Xây dựng website wordpress tại bất cứ đâu", null, "Wordpress", true },
                    { 2, 1, "Cùng đội ngũ freelancer xây dựng website của bạn.", null, "Website development", true },
                    { 3, 1, "Bảo trì hệ thống bằng đội ngũ freelancer.", null, "Website maintainance", true },
                    { 4, 2, "Chỉnh sửa những bức ảnh đẹp cùng đội ngũ chúng tôi.", null, "Photo Design", true },
                    { 5, 2, "Thiết kế đồ họa 2D theo yêu cầu của bạn", null, "Design 2D", true },
                    { 6, 2, "Thiết kế ý tưởng & đồ họa cho game ", null, "Graphics Game", false },
                    { 7, 3, "Edit video với chất lượng tuyệt vời", null, "Video Edition", true },
                    { 8, 3, "Làm ra thước phim hoạt hình vượt ngoài trí tưởng tượng.", null, "Animation Creating", true },
                    { 9, 3, "Hướng dẫn chỉnh sửa video một cách tận tình", null, "Video Teaching", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "PostId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "SubCateId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "SubCateId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "SubCateId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "SubCateId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "SubCateId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "SubCateId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "SubCateId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "SubCateId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "SubCateId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 6, 18, 16, 41, 158, DateTimeKind.Local).AddTicks(6004),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 6, 18, 39, 43, 154, DateTimeKind.Local).AddTicks(6416));
        }
    }
}
