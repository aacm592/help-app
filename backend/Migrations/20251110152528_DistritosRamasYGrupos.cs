using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class DistritosRamasYGrupos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "GruposScout",
                columns: new[] { "Id", "DistritoId", "Nombre" },
                values: new object[] { 2, 2, "Cobija" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GruposScout",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "GruposScout",
                columns: new[] { "Id", "DistritoId", "Nombre" },
                values: new object[] { 3, 2, "Cobija" });
        }
    }
}
