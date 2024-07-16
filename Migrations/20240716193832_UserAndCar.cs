using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEB_API_1_Paskaita.Migrations
{
    /// <inheritdoc />
    public partial class UserAndCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SafetyCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyCars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SafetyCars",
                columns: new[] { "Id", "Brand", "Color", "Model" },
                values: new object[,]
                {
                    { 1, "Aston Martin", "Green Metalic", "Vantage" },
                    { 2, "Mercedes-Benz", "Black", "AMG GT Black Series" },
                    { 3, "Mercedes-Benz", "Silver", "AMG GT R" },
                    { 4, "Lamborghini", "Red", "Diablo" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "CreationDateTime", "Email", "UserName" },
                values: new object[,]
                {
                    { new Guid("686bbd3f-17e2-46b1-8162-a2fb20e514c2"), "New York", new DateTime(2024, 7, 16, 19, 38, 32, 517, DateTimeKind.Utc).AddTicks(7107), "johndoe@example.com", "JohnDoe" },
                    { new Guid("7202316e-cc60-4c98-9bee-03c0a964fe3e"), "Los Angeles", new DateTime(2024, 7, 16, 19, 38, 32, 517, DateTimeKind.Utc).AddTicks(7126), "janedoe@example.com", "JaneDoe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SafetyCars");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
