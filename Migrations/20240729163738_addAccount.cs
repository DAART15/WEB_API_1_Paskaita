using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEB_API_1_Paskaita.Migrations
{
    /// <inheritdoc />
    public partial class addAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4b7d9e58-3af0-4de0-8a80-0139135f14f6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c74d6a7f-ffec-467e-ba80-610d7d117869"));

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 37, 38, 76, DateTimeKind.Local).AddTicks(6095), new DateTime(2024, 7, 29, 19, 37, 38, 76, DateTimeKind.Local).AddTicks(6138) });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 37, 38, 76, DateTimeKind.Local).AddTicks(6140), new DateTime(2024, 7, 29, 19, 37, 38, 76, DateTimeKind.Local).AddTicks(6141) });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 37, 38, 76, DateTimeKind.Local).AddTicks(6142), new DateTime(2024, 7, 29, 19, 37, 38, 76, DateTimeKind.Local).AddTicks(6143) });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 37, 38, 76, DateTimeKind.Local).AddTicks(6144), new DateTime(2024, 7, 29, 19, 37, 38, 76, DateTimeKind.Local).AddTicks(6145) });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 37, 38, 76, DateTimeKind.Local).AddTicks(6146), new DateTime(2024, 7, 29, 19, 37, 38, 76, DateTimeKind.Local).AddTicks(6147) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "CreationDateTime", "Email", "UserName" },
                values: new object[,]
                {
                    { new Guid("bcfdb5b6-df09-4242-96d4-5bb16b21fa1a"), "New York", new DateTime(2024, 7, 29, 16, 37, 38, 76, DateTimeKind.Utc).AddTicks(4834), "johndoe@example.com", "JohnDoe" },
                    { new Guid("da7c7f4f-dd76-4b55-9b52-6755caaf4ac2"), "Los Angeles", new DateTime(2024, 7, 29, 16, 37, 38, 76, DateTimeKind.Utc).AddTicks(4846), "janedoe@example.com", "JaneDoe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bcfdb5b6-df09-4242-96d4-5bb16b21fa1a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("da7c7f4f-dd76-4b55-9b52-6755caaf4ac2"));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 18, 21, 42, 8, 973, DateTimeKind.Local).AddTicks(8547), new DateTime(2024, 7, 18, 21, 42, 8, 973, DateTimeKind.Local).AddTicks(8586) });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 18, 21, 42, 8, 973, DateTimeKind.Local).AddTicks(8588), new DateTime(2024, 7, 18, 21, 42, 8, 973, DateTimeKind.Local).AddTicks(8589) });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 18, 21, 42, 8, 973, DateTimeKind.Local).AddTicks(8590), new DateTime(2024, 7, 18, 21, 42, 8, 973, DateTimeKind.Local).AddTicks(8591) });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 18, 21, 42, 8, 973, DateTimeKind.Local).AddTicks(8592), new DateTime(2024, 7, 18, 21, 42, 8, 973, DateTimeKind.Local).AddTicks(8593) });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 18, 21, 42, 8, 973, DateTimeKind.Local).AddTicks(8594), new DateTime(2024, 7, 18, 21, 42, 8, 973, DateTimeKind.Local).AddTicks(8595) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "CreationDateTime", "Email", "UserName" },
                values: new object[,]
                {
                    { new Guid("4b7d9e58-3af0-4de0-8a80-0139135f14f6"), "New York", new DateTime(2024, 7, 18, 18, 42, 8, 973, DateTimeKind.Utc).AddTicks(7784), "johndoe@example.com", "JohnDoe" },
                    { new Guid("c74d6a7f-ffec-467e-ba80-610d7d117869"), "Los Angeles", new DateTime(2024, 7, 18, 18, 42, 8, 973, DateTimeKind.Utc).AddTicks(7801), "janedoe@example.com", "JaneDoe" }
                });
        }
    }
}
