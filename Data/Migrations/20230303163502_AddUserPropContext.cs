using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddUserPropContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 3, 23, 35, 2, 201, DateTimeKind.Local).AddTicks(1225),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 28, 16, 47, 21, 259, DateTimeKind.Local).AddTicks(6712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AlterColumn<bool>(
                name: "IsPostPublic",
                table: "Post",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "AppUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slogan",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("1dee62ee-ae2c-4417-a65c-74e992b1ca32"),
                column: "ConcurrencyStamp",
                value: "e0f20dbb-df7a-4304-874c-a533bf33f442");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("6859dc0f-5f7d-47e1-b35d-bd45acf3f3c8"),
                column: "ConcurrencyStamp",
                value: "08da7c30-4e8f-4ab9-bffe-a0736d4ec103");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("bd839b07-beac-492e-8688-e3522a60476e"),
                column: "ConcurrencyStamp",
                value: "bc38e530-ce39-43b6-b877-d2b4c20c9b5f");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("a27ed6da-8f70-4a41-82cd-2fb50dabeb18"),
                columns: new[] { "ConcurrencyStamp", "MemberSince", "PasswordHash" },
                values: new object[] { "ad9ba386-f392-42aa-a181-fe30ae826b6d", new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Local), "AQAAAAEAACcQAAAAENgbgGHPAqAZqw/FTnJ8B2+O/G/uJPg/ReDC+1fnXInMuLmBw8Qo9nbDGF40hYJEzg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Slogan",
                table: "AppUser");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 28, 16, 47, 21, 259, DateTimeKind.Local).AddTicks(6712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 3, 23, 35, 2, 201, DateTimeKind.Local).AddTicks(1225));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AlterColumn<bool>(
                name: "IsPostPublic",
                table: "Post",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "AppUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("1dee62ee-ae2c-4417-a65c-74e992b1ca32"),
                column: "ConcurrencyStamp",
                value: "9e674a42-e053-4a08-9aa9-e710f6ebd274");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("6859dc0f-5f7d-47e1-b35d-bd45acf3f3c8"),
                column: "ConcurrencyStamp",
                value: "2ca106b4-7ce0-4496-96f0-1826c1a9748a");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("bd839b07-beac-492e-8688-e3522a60476e"),
                column: "ConcurrencyStamp",
                value: "f82ebe35-aa00-4775-9610-ced1447a3c8d");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("a27ed6da-8f70-4a41-82cd-2fb50dabeb18"),
                columns: new[] { "ConcurrencyStamp", "MemberSince", "PasswordHash" },
                values: new object[] { "482d55cf-fe9f-4bea-bd19-a94826cf4f72", new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Local), "AQAAAAEAACcQAAAAEAOMqmkHVZLQpPudDWzIt3fw7hb9M3FVo3UPSJUK3LPY+fVt5Law+0kV75ZpoocJXg==" });
        }
    }
}
