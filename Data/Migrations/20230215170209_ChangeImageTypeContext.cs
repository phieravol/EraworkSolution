using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ChangeImageTypeContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("86bde3bb-e3cc-41d9-b8c3-98e796d63907"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("d33fe90a-dba1-4f78-98f0-9a304cda119d"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("edbb02ea-b990-4bdc-8ece-3e625496755d"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("97869d40-86bf-44e6-b5fe-da831bc70f1c"));

            migrationBuilder.DeleteData(
                table: "AppUserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("edbb02ea-b990-4bdc-8ece-3e625496755d"), new Guid("97869d40-86bf-44e6-b5fe-da831bc70f1c") });

            migrationBuilder.AlterColumn<string>(
                name: "SubcateImage",
                table: "SubCategory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 16, 0, 2, 9, 346, DateTimeKind.Local).AddTicks(9397),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 13, 23, 50, 14, 255, DateTimeKind.Local).AddTicks(6573));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AlterColumn<string>(
                name: "CategoryImage",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "AppUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Local));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<byte[]>(
                name: "SubcateImage",
                table: "SubCategory",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 13, 23, 50, 14, 255, DateTimeKind.Local).AddTicks(6573),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 16, 0, 2, 9, 346, DateTimeKind.Local).AddTicks(9397));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AlterColumn<byte[]>(
                name: "CategoryImage",
                table: "Category",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "AppUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "RoleDesc" },
                values: new object[,]
                {
                    { new Guid("86bde3bb-e3cc-41d9-b8c3-98e796d63907"), "41c599c9-faaf-470c-abcf-389219b5bf06", "Provider", null, "Provide service for client" },
                    { new Guid("d33fe90a-dba1-4f78-98f0-9a304cda119d"), "39ca7c76-ea78-4192-8976-9d05b65ad5c4", "Client", null, "Can order services from provider" },
                    { new Guid("edbb02ea-b990-4bdc-8ece-3e625496755d"), "7fabf553-22a3-40c2-b433-877cc769608b", "Admin", null, "Can Custom system" }
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MemberSince", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserDesc", "UserLable", "UserLevel", "UserName", "UserStatus" },
                values: new object[] { new Guid("97869d40-86bf-44e6-b5fe-da831bc70f1c"), 0, "4084cea0-8286-4f4a-96cd-625329f73bb7", "phinqhe153034@fpt.edu.vn", false, "Nguyễn", "Quốc Phi", false, null, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Local), null, null, "AQAAAAEAACcQAAAAEGfX1YDDvnh7y/E8/MMtkyAndI5k7Wv0+sjaUq1HsRM4bQNfPguHt0WHEJDfYKweHw==", null, false, "", false, "Tôi là một Designer, chuyên design sự tương tư của bạn :))", "", 1, "phiphongphanh", 1 });

            migrationBuilder.InsertData(
                table: "AppUserRole",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { new Guid("edbb02ea-b990-4bdc-8ece-3e625496755d"), new Guid("97869d40-86bf-44e6-b5fe-da831bc70f1c"), "IdentityUserRole<Guid>" });
        }
    }
}
