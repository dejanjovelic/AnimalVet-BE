using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Exam.App.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "AnimalSpeciesId", "DateOfBirth", "Name", "OwnerId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 2, 20, 19, 19, 9, 690, DateTimeKind.Utc).AddTicks(3082), "Micka", 1 },
                    { 2, 1, new DateTime(2025, 10, 20, 19, 19, 9, 690, DateTimeKind.Utc).AddTicks(3090), "Crni", 1 },
                    { 3, 3, new DateTime(2025, 2, 20, 19, 19, 9, 690, DateTimeKind.Utc).AddTicks(3092), "Rasa", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
