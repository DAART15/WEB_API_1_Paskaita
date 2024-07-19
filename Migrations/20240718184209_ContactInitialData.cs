using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEB_API_1_Paskaita.Migrations
{
    /// <inheritdoc />
    public partial class ContactInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00ebb7a2-3dd1-4987-a473-1f2b34fad56e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3f865fb7-a366-44ad-ab17-b8df12bf29a0"));

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Company", "CreatedAt", "FirstName", "LastName", "Mail", "Note", "PhoneNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "DAART15", new DateTime(2024, 7, 18, 21, 42, 8, 973, DateTimeKind.Local).AddTicks(8547), "Ramas", "Darr", "ramas@daart15.com", "mano kontaktas", "+37023456789", new DateTime(2024, 7, 18, 21, 42, 8, 973, DateTimeKind.Local).AddTicks(8586) },
                    { 2, "UAB Tadilis", new DateTime(2024, 7, 18, 21, 42, 8, 973, DateTimeKind.Local).AddTicks(8588), "Tadas", "Tadulis", "tadas@tadulis.com", "", "+370234", new DateTime(2024, 7, 18, 21, 42, 8, 973, DateTimeKind.Local).AddTicks(8589) },
                    { 3, "DAART15", new DateTime(2024, 7, 18, 21, 42, 8, 973, DateTimeKind.Local).AddTicks(8590), "Andius", "Daar", "andriusl@daart15.com", "vyr. kontaktas", "+37023456799", new DateTime(2024, 7, 18, 21, 42, 8, 973, DateTimeKind.Local).AddTicks(8591) },
                    { 4, "DAART15", new DateTime(2024, 7, 18, 21, 42, 8, 973, DateTimeKind.Local).AddTicks(8592), "Arma", "Daar", "arma@daart15.com", "junior kontaktas", "+37023456788", new DateTime(2024, 7, 18, 21, 42, 8, 973, DateTimeKind.Local).AddTicks(8593) },
                    { 5, "DAART15", new DateTime(2024, 7, 18, 21, 42, 8, 973, DateTimeKind.Local).AddTicks(8594), "Daiva", "Darr", "daiva@daart15.com", "paciausias kontaktas", "+3702345639", new DateTime(2024, 7, 18, 21, 42, 8, 973, DateTimeKind.Local).AddTicks(8595) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "CreationDateTime", "Email", "UserName" },
                values: new object[,]
                {
                    { new Guid("4b7d9e58-3af0-4de0-8a80-0139135f14f6"), "New York", new DateTime(2024, 7, 18, 18, 42, 8, 973, DateTimeKind.Utc).AddTicks(7784), "johndoe@example.com", "JohnDoe" },
                    { new Guid("c74d6a7f-ffec-467e-ba80-610d7d117869"), "Los Angeles", new DateTime(2024, 7, 18, 18, 42, 8, 973, DateTimeKind.Utc).AddTicks(7801), "janedoe@example.com", "JaneDoe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4b7d9e58-3af0-4de0-8a80-0139135f14f6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c74d6a7f-ffec-467e-ba80-610d7d117869"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "CreationDateTime", "Email", "UserName" },
                values: new object[,]
                {
                    { new Guid("00ebb7a2-3dd1-4987-a473-1f2b34fad56e"), "Los Angeles", new DateTime(2024, 7, 18, 18, 29, 9, 78, DateTimeKind.Utc).AddTicks(2134), "janedoe@example.com", "JaneDoe" },
                    { new Guid("3f865fb7-a366-44ad-ab17-b8df12bf29a0"), "New York", new DateTime(2024, 7, 18, 18, 29, 9, 78, DateTimeKind.Utc).AddTicks(2114), "johndoe@example.com", "JohnDoe" }
                });
        }
    }
}
