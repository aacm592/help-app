using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedGruposFromCsv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Distritos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nombre",
                value: "Beni");

            migrationBuilder.UpdateData(
                table: "Distritos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nombre",
                value: "Chuquisaca");

            migrationBuilder.InsertData(
                table: "Distritos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 3, "Cochabamba" },
                    { 4, "La Paz" },
                    { 5, "Oruro" },
                    { 6, "Potosi" },
                    { 7, "Santa Cruz" },
                    { 8, "Tarija" }
                });

            migrationBuilder.UpdateData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nombre",
                value: "LA SALLE");

            migrationBuilder.UpdateData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nombre",
                value: "ALEMÁN");

            migrationBuilder.InsertData(
                table: "GruposScout",
                columns: new[] { "Id", "DistritoId", "Nombre" },
                values: new object[,]
                {
                    { 3, 2, "APACHE" },
                    { 4, 2, "DON BOSCO" },
                    { 5, 2, "HEIMDALL" },
                    { 6, 2, "JUNÍN" },
                    { 7, 2, "SAGRADO CORAZÓN" },
                    { 8, 3, "ANGLO AMERICANO" },
                    { 9, 3, "BROWNSEA" },
                    { 10, 3, "CEIBO" },
                    { 11, 3, "ESPAÑA" },
                    { 12, 3, "FORTALEZA" },
                    { 13, 3, "IMPEESA" },
                    { 14, 3, "INCAS" },
                    { 15, 3, "INTIDRAC" },
                    { 16, 3, "KAIROS" },
                    { 17, 3, "LA SALLE" },
                    { 18, 3, "MAFEKING" },
                    { 19, 3, "MURRAY DICKSON" },
                    { 20, 3, "PANDA" },
                    { 21, 3, "PRIMAVERA" },
                    { 22, 3, "SAINT ANDREW'S" },
                    { 23, 3, "SEMILLA" },
                    { 24, 3, "TUNARI" },
                    { 25, 4, "AMERINST 301" },
                    { 26, 4, "BOLIVIANO ISRAELITA" },
                    { 27, 4, "HANS PHILIPPSBERG SAINT ANDREW'S SCHOOL" },
                    { 28, 4, "IMPEESA" },
                    { 29, 4, "LOS PINOS" },
                    { 30, 4, "LOS ROBLES" },
                    { 31, 4, "LOYOLA SAN CALIXTO" },
                    { 32, 4, "LOYOLA SAN IGNACIO" },
                    { 33, 4, "NAVAL ALMTE MIGUEL GRAU S." },
                    { 34, 4, "NAVAL CRUX UENHP." },
                    { 35, 5, "CAMACHO" },
                    { 36, 5, "CAP. USTARIZ" },
                    { 37, 5, "DRAGONES" },
                    { 38, 5, "LA SALLE" },
                    { 39, 5, "MEJILLONES" },
                    { 40, 5, "SAN FRANCISCO" },
                    { 41, 5, "VIKING´S" },
                    { 42, 6, "MAFEKING" },
                    { 43, 6, "Ri 3 PEREZ" },
                    { 44, 6, "TORRE FUERTE" },
                    { 45, 7, "AMBORÓ" },
                    { 46, 7, "ARGENTINO BOLIVIANO" },
                    { 47, 7, "DON BOSCO" },
                    { 48, 7, "GASTÓN GUILLAUX" },
                    { 49, 7, "JUAN PABLO II" },
                    { 50, 7, "LA 7" },
                    { 51, 7, "MARISTA" },
                    { 52, 7, "SAN ANDRÉS" },
                    { 53, 7, "SANTA ANA" },
                    { 54, 7, "SANTO TOMÁS" },
                    { 55, 8, "LA SALLE" },
                    { 56, 8, "SAN MARTIN DE PORRES" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Distritos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Distritos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Distritos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Distritos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Distritos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Distritos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Distritos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nombre",
                value: "Cochabamba");

            migrationBuilder.UpdateData(
                table: "Distritos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nombre",
                value: "Pando");

            migrationBuilder.UpdateData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nombre",
                value: "Tunari");

            migrationBuilder.UpdateData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nombre",
                value: "Cobija");
        }
    }
}
