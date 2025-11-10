using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedDistritosRamasYGrupos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NivelAcceso",
                table: "Ramas");

            migrationBuilder.InsertData(
                table: "Distritos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Cochabamba" },
                    { 2, "Pando" }
                });

            migrationBuilder.InsertData(
                table: "Ramas",
                columns: new[] { "Id", "EdadMaxima", "EdadMinima", "Nombre" },
                values: new object[,]
                {
                    { 1, 11, 7, "Lobatos" },
                    { 2, 14, 11, "Exploradores" },
                    { 3, 17, 14, "Pioneros" },
                    { 4, 22, 17, "Rovers" }
                });

            migrationBuilder.InsertData(
                table: "GruposScout",
                columns: new[] { "Id", "DistritoId", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Tunari" },
                    { 3, 2, "Cobija" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ramas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ramas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ramas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ramas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Distritos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Distritos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "NivelAcceso",
                table: "Ramas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
