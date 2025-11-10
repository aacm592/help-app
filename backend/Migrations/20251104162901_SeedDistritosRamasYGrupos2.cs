using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedDistritosRamasYGrupos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ramas",
                keyColumn: "Id",
                keyValue: 2,
                column: "EdadMaxima",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Ramas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EdadMaxima", "EdadMinima" },
                values: new object[] { 18, 15 });

            migrationBuilder.UpdateData(
                table: "Ramas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EdadMaxima", "EdadMinima" },
                values: new object[] { 21, 18 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ramas",
                keyColumn: "Id",
                keyValue: 2,
                column: "EdadMaxima",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Ramas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EdadMaxima", "EdadMinima" },
                values: new object[] { 17, 14 });

            migrationBuilder.UpdateData(
                table: "Ramas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EdadMaxima", "EdadMinima" },
                values: new object[] { 22, 17 });
        }
    }
}
