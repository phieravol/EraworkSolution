using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class UpdatePostContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2023, 2, 26, 14, 32, 41, 771, DateTimeKind.Local).AddTicks(6862),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 22, 21, 48, 48, 661, DateTimeKind.Local).AddTicks(9330));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "PostStatus",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProviderLevel",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalRequest",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "AppUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "RoleDesc" },
                values: new object[,]
                {
                    { new Guid("1dee62ee-ae2c-4417-a65c-74e992b1ca32"), "141eea7b-1374-4c89-8fbb-b1c35527fe6b", "Admin", null, "Can Custom system" },
                    { new Guid("6859dc0f-5f7d-47e1-b35d-bd45acf3f3c8"), "b896aca4-39ff-4055-8be7-f92890c7d079", "Client", null, "Can order services from provider" },
                    { new Guid("bd839b07-beac-492e-8688-e3522a60476e"), "6c320027-fd90-4ab2-b233-3e0e5048b47a", "Provider", null, "Provide service for client" }
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MemberSince", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserDesc", "UserLable", "UserLevel", "UserName", "UserStatus" },
                values: new object[] { new Guid("a27ed6da-8f70-4a41-82cd-2fb50dabeb18"), 0, "32f1a3a1-27af-42eb-b5da-0c2afe0947e2", "phinqhe153034@fpt.edu.vn", false, "Nguyễn", "Quốc Phi", false, null, new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), null, null, "AQAAAAEAACcQAAAAEHQo7QuY26+ohfZEjpxp7GlggEwqmViLkAGvaPzEv3qtOHfEiQqZPgAAXLtxvuevQQ==", null, false, "", false, "Tôi là một Designer, chuyên design sự tương tư của bạn :))", "", 1, "phinq", 1 });

            migrationBuilder.InsertData(
                table: "AppUserRole",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { new Guid("1dee62ee-ae2c-4417-a65c-74e992b1ca32"), new Guid("a27ed6da-8f70-4a41-82cd-2fb50dabeb18"), "IdentityUserRole<Guid>" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("1dee62ee-ae2c-4417-a65c-74e992b1ca32"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("6859dc0f-5f7d-47e1-b35d-bd45acf3f3c8"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("bd839b07-beac-492e-8688-e3522a60476e"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("a27ed6da-8f70-4a41-82cd-2fb50dabeb18"));

            migrationBuilder.DeleteData(
                table: "AppUserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("1dee62ee-ae2c-4417-a65c-74e992b1ca32"), new Guid("a27ed6da-8f70-4a41-82cd-2fb50dabeb18") });

            migrationBuilder.DropColumn(
                name: "PostStatus",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "ProviderLevel",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "TotalRequest",
                table: "Post");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 22, 21, 48, 48, 661, DateTimeKind.Local).AddTicks(9330),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 26, 14, 32, 41, 771, DateTimeKind.Local).AddTicks(6862));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "AppUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Local));

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
    }
}
