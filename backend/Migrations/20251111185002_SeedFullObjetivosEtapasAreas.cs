using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedFullObjetivosEtapasAreas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "ObjetivosEducativos");

            migrationBuilder.DropColumn(
                name: "EtapaId",
                table: "ObjetivosEducativos");

            migrationBuilder.InsertData(
                table: "AreasCrecimiento",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Corporalidad" },
                    { 2, "Carácter" },
                    { 3, "Afectividad" },
                    { 4, "Sociabilidad" },
                    { 5, "Espiritualidad" },
                    { 6, "Creatividad" }
                });

            migrationBuilder.InsertData(
                table: "EtapasProgresion",
                columns: new[] { "Id", "Nombre", "RamaId" },
                values: new object[,]
                {
                    { 1, "Pata tierna - Saltador", 1 },
                    { 2, "Rastreador - Cazador", 1 },
                    { 3, "Pista - Senda", 2 },
                    { 4, "Rumbo - Travesía", 2 },
                    { 5, "Busqueda - Encuentro - Desafío", 3 },
                    { 6, "Caminante - Aspirante - Rover", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AreasCrecimiento",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AreasCrecimiento",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AreasCrecimiento",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AreasCrecimiento",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AreasCrecimiento",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AreasCrecimiento",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EtapasProgresion",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EtapasProgresion",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EtapasProgresion",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EtapasProgresion",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EtapasProgresion",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EtapasProgresion",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "ObjetivosEducativos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EtapaId",
                table: "ObjetivosEducativos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
