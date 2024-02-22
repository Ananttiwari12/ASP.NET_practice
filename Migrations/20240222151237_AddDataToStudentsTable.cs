using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASP.NET_tut.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToStudentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "DOB", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "katni", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "an@gmial.com", "Anant" },
                    { 2, "katni", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "an2@gmial.com", "Anant2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
