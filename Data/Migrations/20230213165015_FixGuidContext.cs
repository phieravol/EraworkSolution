using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class FixGuidContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("298914d6-c02e-4d77-88a6-36a87efb28d1"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("52fc3cf4-fda5-45b3-b647-02e7926ddb69"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("c71500c3-76af-4740-a9f5-5c5b886baaf4"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("8da49120-f322-418e-b6be-259401f83537"));

            migrationBuilder.DeleteData(
                table: "AppUserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c71500c3-76af-4740-a9f5-5c5b886baaf4"), new Guid("8da49120-f322-418e-b6be-259401f83537") });

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 13, 23, 50, 14, 255, DateTimeKind.Local).AddTicks(6573),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 13, 16, 5, 50, 945, DateTimeKind.Local).AddTicks(4523));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 13, 16, 5, 50, 945, DateTimeKind.Local).AddTicks(4523),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 13, 23, 50, 14, 255, DateTimeKind.Local).AddTicks(6573));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "RoleDesc" },
                values: new object[,]
                {
                    { new Guid("298914d6-c02e-4d77-88a6-36a87efb28d1"), "0e2c2cfa-9d7d-4d0f-89ec-f51e0c0728b8", "Client", null, "Can order services from provider" },
                    { new Guid("52fc3cf4-fda5-45b3-b647-02e7926ddb69"), "27ee5b16-d942-4fee-8457-2e75347069a3", "Provider", null, "Provide service for client" },
                    { new Guid("c71500c3-76af-4740-a9f5-5c5b886baaf4"), "6f006b23-b539-456f-91d1-58c03a213918", "Admin", null, "Can Custom system" }
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MemberSince", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserDesc", "UserLable", "UserLevel", "UserName", "UserStatus" },
                values: new object[] { new Guid("8da49120-f322-418e-b6be-259401f83537"), 0, "8fc7f14c-afb6-4d9e-907c-8d5fae42873d", "phinqhe153034@fpt.edu.vn", false, "Nguyễn", "Quốc Phi", false, null, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Local), null, null, "AQAAAAEAACcQAAAAEJ2Vthft0kXBSE2KQEVFxQ4yTG+DfQNnYcRntnIEUND4EZ59coE6/e4vxuZUnW7Y3Q==", null, false, "", false, "Tôi là một Designer, chuyên design sự tương tư của bạn :))", "", 1, "phiphongphanh", 1 });

            migrationBuilder.InsertData(
                table: "AppUserRole",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { new Guid("c71500c3-76af-4740-a9f5-5c5b886baaf4"), new Guid("8da49120-f322-418e-b6be-259401f83537"), "IdentityUserRole<Guid>" });
        }
    }
}
