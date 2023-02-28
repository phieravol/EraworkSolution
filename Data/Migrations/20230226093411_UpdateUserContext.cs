using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class UpdateUserContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 26, 16, 34, 10, 672, DateTimeKind.Local).AddTicks(3882),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 26, 15, 10, 19, 41, DateTimeKind.Local).AddTicks(1553));

            migrationBuilder.AlterColumn<string>(
                name: "UserLevel",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 1);

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("1dee62ee-ae2c-4417-a65c-74e992b1ca32"),
                column: "ConcurrencyStamp",
                value: "53c9a720-3d3f-4518-8ae7-8296b3d37731");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("6859dc0f-5f7d-47e1-b35d-bd45acf3f3c8"),
                column: "ConcurrencyStamp",
                value: "e656a330-e0c9-4985-8f63-e8b8ccb03afb");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("bd839b07-beac-492e-8688-e3522a60476e"),
                column: "ConcurrencyStamp",
                value: "6860cac1-bc33-4a0c-8c85-8d9486bcee22");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("a27ed6da-8f70-4a41-82cd-2fb50dabeb18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserLevel" },
                values: new object[] { "f60df7fe-f5e3-4bfc-8b40-5ed7a4555977", "AQAAAAEAACcQAAAAEFLaFtDx4kdufknZcbbt9NciB2XOcJIa0D5JUwGUNidnkCEj/WLbg3owIp5mKHT5cw==", "Other" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 26, 15, 10, 19, 41, DateTimeKind.Local).AddTicks(1553),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 26, 16, 34, 10, 672, DateTimeKind.Local).AddTicks(3882));

            migrationBuilder.AlterColumn<int>(
                name: "UserLevel",
                table: "AppUser",
                type: "int",
                nullable: true,
                defaultValue: 1,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("1dee62ee-ae2c-4417-a65c-74e992b1ca32"),
                column: "ConcurrencyStamp",
                value: "d4c2452c-53a1-407a-b98b-8864f6476cba");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("6859dc0f-5f7d-47e1-b35d-bd45acf3f3c8"),
                column: "ConcurrencyStamp",
                value: "0f12d7f6-0fbd-4e3c-b6ac-4f9b66b31e09");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("bd839b07-beac-492e-8688-e3522a60476e"),
                column: "ConcurrencyStamp",
                value: "c767bdde-b268-4364-a12f-c5a3a6208028");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("a27ed6da-8f70-4a41-82cd-2fb50dabeb18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserLevel" },
                values: new object[] { "ee975f1b-515a-4aeb-9aec-13a3bc44105d", "AQAAAAEAACcQAAAAEP+mtKxogesmNeAeKoFMWW9bTWyUSeql/mQaDuY4QDJ0RoBw6zMIpreV0gpHBby1UQ==", 1 });
        }
    }
}
