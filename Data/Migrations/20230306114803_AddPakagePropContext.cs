using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddPakagePropContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pakage_Service_ServiceId",
                table: "Pakage");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 6, 18, 48, 2, 900, DateTimeKind.Local).AddTicks(2742),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 4, 0, 22, 18, 897, DateTimeKind.Local).AddTicks(9090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "Pakage",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "AppUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Local));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Pakage_Service_ServiceId",
                table: "Pakage",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pakage_Service_ServiceId",
                table: "Pakage");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 4, 0, 22, 18, 897, DateTimeKind.Local).AddTicks(9090),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 6, 18, 48, 2, 900, DateTimeKind.Local).AddTicks(2742));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "Pakage",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "AppUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("1dee62ee-ae2c-4417-a65c-74e992b1ca32"),
                column: "ConcurrencyStamp",
                value: "0e370117-fb60-4d5d-b9bc-4dde491c62cc");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("6859dc0f-5f7d-47e1-b35d-bd45acf3f3c8"),
                column: "ConcurrencyStamp",
                value: "a18c213c-fc86-4da0-8d4f-6b089e801146");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("bd839b07-beac-492e-8688-e3522a60476e"),
                column: "ConcurrencyStamp",
                value: "22bf4492-8717-4c84-b445-e335fdcd5955");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("a27ed6da-8f70-4a41-82cd-2fb50dabeb18"),
                columns: new[] { "ConcurrencyStamp", "MemberSince", "PasswordHash" },
                values: new object[] { "a18fa923-62ea-4b15-8989-fd25a11d7d45", new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Local), "AQAAAAEAACcQAAAAEDjVlkELcMJxJqd2VJKY+3d5JwNkTQ5TbeFwDwv+mALk3hoUZkttYKDrr8l8Gq64/g==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pakage_Service_ServiceId",
                table: "Pakage",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId");
        }
    }
}
