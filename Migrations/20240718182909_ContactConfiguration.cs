using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEB_API_1_Paskaita.Migrations
{
    /// <inheritdoc />
    public partial class ContactConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("686bbd3f-17e2-46b1-8162-a2fb20e514c2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7202316e-cc60-4c98-9bee-03c0a964fe3e"));

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "CreationDateTime", "Email", "UserName" },
                values: new object[,]
                {
                    { new Guid("00ebb7a2-3dd1-4987-a473-1f2b34fad56e"), "Los Angeles", new DateTime(2024, 7, 18, 18, 29, 9, 78, DateTimeKind.Utc).AddTicks(2134), "janedoe@example.com", "JaneDoe" },
                    { new Guid("3f865fb7-a366-44ad-ab17-b8df12bf29a0"), "New York", new DateTime(2024, 7, 18, 18, 29, 9, 78, DateTimeKind.Utc).AddTicks(2114), "johndoe@example.com", "JohnDoe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00ebb7a2-3dd1-4987-a473-1f2b34fad56e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3f865fb7-a366-44ad-ab17-b8df12bf29a0"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "CreationDateTime", "Email", "UserName" },
                values: new object[,]
                {
                    { new Guid("686bbd3f-17e2-46b1-8162-a2fb20e514c2"), "New York", new DateTime(2024, 7, 16, 19, 38, 32, 517, DateTimeKind.Utc).AddTicks(7107), "johndoe@example.com", "JohnDoe" },
                    { new Guid("7202316e-cc60-4c98-9bee-03c0a964fe3e"), "Los Angeles", new DateTime(2024, 7, 16, 19, 38, 32, 517, DateTimeKind.Utc).AddTicks(7126), "janedoe@example.com", "JaneDoe" }
                });
        }
    }
}
