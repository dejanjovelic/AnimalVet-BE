using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Exam.App.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimalSpecies",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "AnimalSpeciesId",
                table: "Patients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AnimalSpecies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalSpecies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AnimalSpecies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pas" },
                    { 2, "Mačka" },
                    { 3, "Papagaj" },
                    { 4, "Kornjača" },
                    { 5, "Zec" },
                    { 6, "Hrčak" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AnimalSpeciesId",
                table: "Patients",
                column: "AnimalSpeciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AnimalSpecies_AnimalSpeciesId",
                table: "Patients",
                column: "AnimalSpeciesId",
                principalTable: "AnimalSpecies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AnimalSpecies_AnimalSpeciesId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "AnimalSpecies");

            migrationBuilder.DropIndex(
                name: "IX_Patients_AnimalSpeciesId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "AnimalSpeciesId",
                table: "Patients");

            migrationBuilder.AddColumn<string>(
                name: "AnimalSpecies",
                table: "Patients",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
