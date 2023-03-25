using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class UpdateServiceDetailContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceDetails",
                table: "Service",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 25, 11, 33, 22, 236, DateTimeKind.Local).AddTicks(3716),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 6, 18, 48, 2, 900, DateTimeKind.Local).AddTicks(2742));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AlterColumn<string>(
                name: "UserLevel",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "beginer",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "AppUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("1dee62ee-ae2c-4417-a65c-74e992b1ca32"),
                column: "ConcurrencyStamp",
                value: "df4e7754-050a-46d7-8ea7-c0734b0a509a");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("6859dc0f-5f7d-47e1-b35d-bd45acf3f3c8"),
                column: "ConcurrencyStamp",
                value: "d48f3b45-999e-45ba-a27e-c84384346d24");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("bd839b07-beac-492e-8688-e3522a60476e"),
                column: "ConcurrencyStamp",
                value: "26e24864-5400-4f5c-bd5b-1eead9885873");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("a27ed6da-8f70-4a41-82cd-2fb50dabeb18"),
                columns: new[] { "ConcurrencyStamp", "MemberSince", "PasswordHash" },
                values: new object[] { "fe552436-5feb-4770-9e4b-c266d93b722b", new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), "AQAAAAEAACcQAAAAEO9CMLDhsdcuaLoc/7FSLKl0z2YsCo/MjSNmHaP0O0myzo7eNDyl3QmT99cfvZtq0w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceDetails",
                table: "Service");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 6, 18, 48, 2, 900, DateTimeKind.Local).AddTicks(2742),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 25, 11, 33, 22, 236, DateTimeKind.Local).AddTicks(3716));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AlterColumn<string>(
                name: "UserLevel",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "beginer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "AppUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("1dee62ee-ae2c-4417-a65c-74e992b1ca32"),
                column: "ConcurrencyStamp",
                value: "7af5f774-a157-466a-b7af-3f6d12e552c6");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("6859dc0f-5f7d-47e1-b35d-bd45acf3f3c8"),
                column: "ConcurrencyStamp",
                value: "c3e348b5-d774-47ba-a934-3714befeb212");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("bd839b07-beac-492e-8688-e3522a60476e"),
                column: "ConcurrencyStamp",
                value: "c6109c68-7065-4d29-aad0-55f71900ed41");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("a27ed6da-8f70-4a41-82cd-2fb50dabeb18"),
                columns: new[] { "ConcurrencyStamp", "MemberSince", "PasswordHash" },
                values: new object[] { "70d5ce57-76a7-4dd5-ae94-efc493b81a15", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Local), "AQAAAAEAACcQAAAAEAQBf4tkViQqoJdr5xXWoQb/G1VuEuMuk5AUD2bBTqrN7mW0AF7RPvosNeDqKe7Gqw==" });
        }
    }
}
