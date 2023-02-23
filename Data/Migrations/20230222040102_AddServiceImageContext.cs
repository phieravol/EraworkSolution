using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddServiceImageContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("4d20eae4-d67b-4eed-afed-bf9cee9ca614"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8026266f-c38f-4562-8eff-8f7b7ecd87ed"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("e753aa2a-aa29-4298-9aa4-09adaa9f3279"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("2a9c1583-3324-4230-bc64-fdad7e1928fc"));

            migrationBuilder.DeleteData(
                table: "AppUserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d20eae4-d67b-4eed-afed-bf9cee9ca614"), new Guid("2a9c1583-3324-4230-bc64-fdad7e1928fc") });

            migrationBuilder.AddColumn<string>(
                name: "ServiceImage",
                table: "Service",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 22, 11, 1, 1, 569, DateTimeKind.Local).AddTicks(1759),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 16, 0, 2, 9, 346, DateTimeKind.Local).AddTicks(9397));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "AppUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Local));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ServiceImage",
                table: "Service");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 16, 0, 2, 9, 346, DateTimeKind.Local).AddTicks(9397),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 22, 11, 1, 1, 569, DateTimeKind.Local).AddTicks(1759));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "AppUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "RoleDesc" },
                values: new object[,]
                {
                    { new Guid("4d20eae4-d67b-4eed-afed-bf9cee9ca614"), "f057c9ab-e964-470e-8f18-77b9d00d33d5", "Admin", null, "Can Custom system" },
                    { new Guid("8026266f-c38f-4562-8eff-8f7b7ecd87ed"), "4efb09d1-12db-48ea-a0dd-d5834ef6c7cb", "Provider", null, "Provide service for client" },
                    { new Guid("e753aa2a-aa29-4298-9aa4-09adaa9f3279"), "fc23756b-9048-4521-ae85-eaacc141742a", "Client", null, "Can order services from provider" }
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MemberSince", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserDesc", "UserLable", "UserLevel", "UserName", "UserStatus" },
                values: new object[] { new Guid("2a9c1583-3324-4230-bc64-fdad7e1928fc"), 0, "bc298584-c551-4f2d-8240-dfdfed82afc3", "phinqhe153034@fpt.edu.vn", false, "Nguyễn", "Quốc Phi", false, null, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Local), null, null, "AQAAAAEAACcQAAAAEJzfVeC6hzSfV993HHLO7ucsXW8uk4ReN2mtyd1zAzJE6hRZWpD69gR7ZhWX/mHGpQ==", null, false, "", false, "Tôi là một Designer, chuyên design sự tương tư của bạn :))", "", 1, "phiphongphanh", 1 });

            migrationBuilder.InsertData(
                table: "AppUserRole",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { new Guid("4d20eae4-d67b-4eed-afed-bf9cee9ca614"), new Guid("2a9c1583-3324-4230-bc64-fdad7e1928fc"), "IdentityUserRole<Guid>" });
        }
    }
}
