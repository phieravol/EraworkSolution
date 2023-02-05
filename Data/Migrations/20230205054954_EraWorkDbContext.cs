using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class EraWorkDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CategoryImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    isCategoryActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    CategoryDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PostDetails = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local)),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Post_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    SubCateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubcateName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SubcateImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    isSubCateActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    SubcateDesc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.SubCateId);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceTitle = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    ServiceIntro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    TotalStars = table.Column<int>(type: "int", nullable: true),
                    TotalClients = table.Column<int>(type: "int", nullable: true),
                    isServiceActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Service_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "SubCateId");
                });

            migrationBuilder.CreateTable(
                name: "OrderRequest",
                columns: table => new
                {
                    OrderRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IsApprove = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    PakageId = table.Column<int>(type: "int", nullable: true),
                    RequestIntro = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRequest", x => x.OrderRequestId);
                    table.ForeignKey(
                        name: "FK_OrderRequest_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId");
                    table.ForeignKey(
                        name: "FK_OrderRequest_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId");
                });

            migrationBuilder.CreateTable(
                name: "Pakage",
                columns: table => new
                {
                    PakageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PakageName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RevisionLimit = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DeliveryDays = table.Column<int>(type: "int", nullable: true),
                    isPakageAcive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pakage", x => x.PakageId);
                    table.ForeignKey(
                        name: "FK_Pakage_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stars = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsHelpfull = table.Column<bool>(type: "bit", nullable: true),
                    ReviewTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 2, 5, 12, 49, 53, 954, DateTimeKind.Local).AddTicks(2295)),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    Liked = table.Column<int>(type: "int", nullable: true),
                    Report = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId");
                });

            migrationBuilder.CreateTable(
                name: "PakageDetail",
                columns: table => new
                {
                    PakageDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PakageDetailDesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDetailActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    PakageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PakageDetail", x => x.PakageDetailId);
                    table.ForeignKey(
                        name: "FK_PakageDetail_Pakage_PakageId",
                        column: x => x.PakageId,
                        principalTable: "Pakage",
                        principalColumn: "PakageId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderRequest_PostId",
                table: "OrderRequest",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRequest_ServiceId",
                table: "OrderRequest",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Pakage_ServiceId",
                table: "Pakage",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PakageDetail_PakageId",
                table: "PakageDetail",
                column: "PakageId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_CategoryId",
                table: "Post",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ServiceId",
                table: "Review",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_SubCategoryId",
                table: "Service",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategory",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderRequest");

            migrationBuilder.DropTable(
                name: "PakageDetail");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Pakage");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
