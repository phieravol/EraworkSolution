using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddAppUserDbSetContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("4f79f5c1-aaba-4076-bfd3-84797d709112"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("86ec40d3-60db-42b7-b6c6-0094c4e10374"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("cd9528c6-30e3-4306-a27b-0501f7559aa6"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("68d38997-9112-42be-b228-97f2faef0785"));

            migrationBuilder.DeleteData(
                table: "AppUserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4f79f5c1-aaba-4076-bfd3-84797d709112"), new Guid("68d38997-9112-42be-b228-97f2faef0785") });

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 22, 21, 48, 48, 661, DateTimeKind.Local).AddTicks(9330),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 22, 11, 1, 1, 569, DateTimeKind.Local).AddTicks(1759));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "RoleDesc" },
                values: new object[,]
                {
                    { new Guid("aba59b2f-094c-4238-ac82-95c5ac187048"), "654b14b2-a485-4154-82c7-5b0e24e05c89", "Provider", null, "Provide service for client" },
                    { new Guid("b098f2aa-00ed-4441-bf08-7a185fdcf223"), "25587c23-0edd-485a-b414-beb12b8dd7cd", "Client", null, "Can order services from provider" },
                    { new Guid("c42ea7d8-71f0-45b2-87b4-4659eea685fe"), "1cef1669-3bef-451e-b671-e044b7bfb1d8", "Admin", null, "Can Custom system" }
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MemberSince", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserDesc", "UserLable", "UserLevel", "UserName", "UserStatus" },
                values: new object[] { new Guid("479f2d36-0a8f-4d41-a4aa-95576ea55c06"), 0, "4cb866ec-4637-4396-bf23-972668e5eb5b", "phinqhe153034@fpt.edu.vn", false, "Nguyễn", "Quốc Phi", false, null, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Local), null, null, "AQAAAAEAACcQAAAAEBXWY+hSEpT2Fou7ks1k+9OvSGrHi5XW7bnvHvfpf/oY+RGpMsDYzwMHjN/hmpyOeA==", null, false, "", false, "Tôi là một Designer, chuyên design sự tương tư của bạn :))", "", 1, "phiphongphanh", 1 });

            migrationBuilder.InsertData(
                table: "AppUserRole",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { new Guid("c42ea7d8-71f0-45b2-87b4-4659eea685fe"), new Guid("479f2d36-0a8f-4d41-a4aa-95576ea55c06"), "IdentityUserRole<Guid>" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("aba59b2f-094c-4238-ac82-95c5ac187048"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("b098f2aa-00ed-4441-bf08-7a185fdcf223"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("c42ea7d8-71f0-45b2-87b4-4659eea685fe"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("479f2d36-0a8f-4d41-a4aa-95576ea55c06"));

            migrationBuilder.DeleteData(
                table: "AppUserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c42ea7d8-71f0-45b2-87b4-4659eea685fe"), new Guid("479f2d36-0a8f-4d41-a4aa-95576ea55c06") });

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 22, 11, 1, 1, 569, DateTimeKind.Local).AddTicks(1759),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 22, 21, 48, 48, 661, DateTimeKind.Local).AddTicks(9330));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "RoleDesc" },
                values: new object[,]
                {
                    { new Guid("4f79f5c1-aaba-4076-bfd3-84797d709112"), "97e592fd-7942-4729-a600-ef1b47717809", "Admin", null, "Can Custom system" },
                    { new Guid("86ec40d3-60db-42b7-b6c6-0094c4e10374"), "b84a80cb-ada4-42b4-b95c-718227a93dc9", "Provider", null, "Provide service for client" },
                    { new Guid("cd9528c6-30e3-4306-a27b-0501f7559aa6"), "122adb3e-6e3e-4023-9bdf-053dd6f570ab", "Client", null, "Can order services from provider" }
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MemberSince", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserDesc", "UserLable", "UserLevel", "UserName", "UserStatus" },
                values: new object[] { new Guid("68d38997-9112-42be-b228-97f2faef0785"), 0, "8379e509-10c2-44cb-98de-e24f3186ab92", "phinqhe153034@fpt.edu.vn", false, "Nguyễn", "Quốc Phi", false, null, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Local), null, null, "AQAAAAEAACcQAAAAEGn64mkvm/7KoBu8ttnjqxM2c5lco+33Ud5qOydCklOkjz2+0nKeZDC+AgA6ySHUxA==", null, false, "", false, "Tôi là một Designer, chuyên design sự tương tư của bạn :))", "", 1, "phiphongphanh", 1 });

            migrationBuilder.InsertData(
                table: "AppUserRole",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { new Guid("4f79f5c1-aaba-4076-bfd3-84797d709112"), new Guid("68d38997-9112-42be-b228-97f2faef0785"), "IdentityUserRole<Guid>" });
        }
    }
}
