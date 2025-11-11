using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class LinkEtapaProgresionToRama : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjetivoUsuario");

            migrationBuilder.RenameColumn(
                name: "Edad",
                table: "EtapasProgresion",
                newName: "RamaId");

            migrationBuilder.CreateTable(
                name: "ObjetivosUsuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    ObjetivoEducativoId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetivosUsuario", x => new { x.UsuarioId, x.ObjetivoEducativoId });
                    table.ForeignKey(
                        name: "FK_ObjetivosUsuario_ObjetivosEducativos_ObjetivoEducativoId",
                        column: x => x.ObjetivoEducativoId,
                        principalTable: "ObjetivosEducativos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjetivosUsuario_Users_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EtapasProgresion_RamaId",
                table: "EtapasProgresion",
                column: "RamaId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetivosUsuario_ObjetivoEducativoId",
                table: "ObjetivosUsuario",
                column: "ObjetivoEducativoId");

            migrationBuilder.AddForeignKey(
                name: "FK_EtapasProgresion_Ramas_RamaId",
                table: "EtapasProgresion",
                column: "RamaId",
                principalTable: "Ramas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EtapasProgresion_Ramas_RamaId",
                table: "EtapasProgresion");

            migrationBuilder.DropTable(
                name: "ObjetivosUsuario");

            migrationBuilder.DropIndex(
                name: "IX_EtapasProgresion_RamaId",
                table: "EtapasProgresion");

            migrationBuilder.RenameColumn(
                name: "RamaId",
                table: "EtapasProgresion",
                newName: "Edad");

            migrationBuilder.CreateTable(
                name: "ObjetivoUsuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    ObjetivoId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetivoUsuario", x => new { x.UsuarioId, x.ObjetivoId });
                    table.ForeignKey(
                        name: "FK_ObjetivoUsuario_ObjetivosEducativos_ObjetivoId",
                        column: x => x.ObjetivoId,
                        principalTable: "ObjetivosEducativos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjetivoUsuario_Users_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjetivoUsuario_ObjetivoId",
                table: "ObjetivoUsuario",
                column: "ObjetivoId");
        }
    }
}
