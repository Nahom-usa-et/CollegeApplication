using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CollegeApplication.Migrations
{
    /// <inheritdoc />
    public partial class SeedStudentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StudentTable",
                columns: new[] { "Id", "ConfirmPassword", "Email", "Name", "addmisiondate", "password", "phone" },
                values: new object[,]
                {
                    { 1, "b1234", "br@gmail.com", "brian", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b1234", "122-123-2312" },
                    { 2, "si431234", "simantha@gmail.com", "Simantha", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "si431234", "452-555-8787" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentTable",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
