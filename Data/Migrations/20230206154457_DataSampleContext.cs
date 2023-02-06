using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class DataSampleContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 6, 22, 44, 57, 377, DateTimeKind.Local).AddTicks(9258),
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
                oldDefaultValue: new DateTime(2023, 2, 6, 22, 44, 57, 377, DateTimeKind.Local).AddTicks(9258));
        }
    }
}
