using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class UpdatePostContext2nd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalRequest",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "ProviderLevel",
                table: "Post",
                newName: "LevelRequired");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 26, 15, 10, 19, 41, DateTimeKind.Local).AddTicks(1553),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 26, 14, 32, 41, 771, DateTimeKind.Local).AddTicks(6862));

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ee975f1b-515a-4aeb-9aec-13a3bc44105d", "AQAAAAEAACcQAAAAEP+mtKxogesmNeAeKoFMWW9bTWyUSeql/mQaDuY4QDJ0RoBw6zMIpreV0gpHBby1UQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LevelRequired",
                table: "Post",
                newName: "ProviderLevel");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 26, 14, 32, 41, 771, DateTimeKind.Local).AddTicks(6862),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 26, 15, 10, 19, 41, DateTimeKind.Local).AddTicks(1553));

            migrationBuilder.AddColumn<int>(
                name: "TotalRequest",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("1dee62ee-ae2c-4417-a65c-74e992b1ca32"),
                column: "ConcurrencyStamp",
                value: "141eea7b-1374-4c89-8fbb-b1c35527fe6b");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("6859dc0f-5f7d-47e1-b35d-bd45acf3f3c8"),
                column: "ConcurrencyStamp",
                value: "b896aca4-39ff-4055-8be7-f92890c7d079");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("bd839b07-beac-492e-8688-e3522a60476e"),
                column: "ConcurrencyStamp",
                value: "6c320027-fd90-4ab2-b233-3e0e5048b47a");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("a27ed6da-8f70-4a41-82cd-2fb50dabeb18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "32f1a3a1-27af-42eb-b5da-0c2afe0947e2", "AQAAAAEAACcQAAAAEHQo7QuY26+ohfZEjpxp7GlggEwqmViLkAGvaPzEv3qtOHfEiQqZPgAAXLtxvuevQQ==" });
        }
    }
}
