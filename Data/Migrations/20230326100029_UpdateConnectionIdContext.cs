using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class UpdateConnectionIdContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 26, 17, 0, 28, 911, DateTimeKind.Local).AddTicks(6800),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 25, 17, 19, 22, 932, DateTimeKind.Local).AddTicks(7698));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "AppUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "UserConnectionId",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("1dee62ee-ae2c-4417-a65c-74e992b1ca32"),
                column: "ConcurrencyStamp",
                value: "ff326338-3437-4509-bc5d-728720b9c9f3");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("6859dc0f-5f7d-47e1-b35d-bd45acf3f3c8"),
                column: "ConcurrencyStamp",
                value: "05be7b68-dcdd-4cd7-9999-537f84df8d96");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("bd839b07-beac-492e-8688-e3522a60476e"),
                column: "ConcurrencyStamp",
                value: "1e8160f1-8459-4a8c-80cf-022aa7c420aa");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("a27ed6da-8f70-4a41-82cd-2fb50dabeb18"),
                columns: new[] { "ConcurrencyStamp", "MemberSince", "PasswordHash" },
                values: new object[] { "7e5fb980-4d33-45fb-b962-9fbbeaa4c25c", new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), "AQAAAAEAACcQAAAAEHcmEHCSZxv5ebtawTEi/Ypz8g1brUzZ8b7FvKdm7FUk8ciaBTFgW7knCeKA2W/peA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserConnectionId",
                table: "AppUser");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 25, 17, 19, 22, 932, DateTimeKind.Local).AddTicks(7698),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 26, 17, 0, 28, 911, DateTimeKind.Local).AddTicks(6800));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "AppUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("1dee62ee-ae2c-4417-a65c-74e992b1ca32"),
                column: "ConcurrencyStamp",
                value: "41faf879-c63b-4aa4-84cc-f57df06eddea");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("6859dc0f-5f7d-47e1-b35d-bd45acf3f3c8"),
                column: "ConcurrencyStamp",
                value: "027d664d-9e53-495e-8fa6-f19efff61ad7");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("bd839b07-beac-492e-8688-e3522a60476e"),
                column: "ConcurrencyStamp",
                value: "ef07c140-2eaa-42b7-a4db-38bf38c73279");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("a27ed6da-8f70-4a41-82cd-2fb50dabeb18"),
                columns: new[] { "ConcurrencyStamp", "MemberSince", "PasswordHash" },
                values: new object[] { "aedafdbd-521b-456e-a0fb-a8df34db58fb", new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), "AQAAAAEAACcQAAAAEPNvIYpsrA5pKTSDDIACfb6mARew5zqFOsvZLgK6HPDRZfz3C8uF//YEPDDF4DrqJQ==" });
        }
    }
}
