using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class registros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gestiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gestiones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    GestionId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    EnvioNacional = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RegistroNacional = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EnvioDistrito = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RegistroDistrito = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RegistroGrupo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Distrito = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Grupo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Unidad = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Rama = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Genero = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Ci = table.Column<int>(type: "integer", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => new { x.GestionId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Registros_Gestiones_GestionId",
                        column: x => x.GestionId,
                        principalTable: "Gestiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registros_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistroDiri",
                columns: table => new
                {
                    GestionId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Profesion = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Ocupacion = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Cargo1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Cargo2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroDiri", x => new { x.GestionId, x.UserId });
                    table.ForeignKey(
                        name: "FK_RegistroDiri_Registros_GestionId_UserId",
                        columns: x => new { x.GestionId, x.UserId },
                        principalTable: "Registros",
                        principalColumns: new[] { "GestionId", "UserId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistroScout",
                columns: table => new
                {
                    GestionId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UnidadEducativa = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    Curso = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Etapa = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroScout", x => new { x.GestionId, x.UserId });
                    table.ForeignKey(
                        name: "FK_RegistroScout_Registros_GestionId_UserId",
                        columns: x => new { x.GestionId, x.UserId },
                        principalTable: "Registros",
                        principalColumns: new[] { "GestionId", "UserId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registros_UserId",
                table: "Registros",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroDiri");

            migrationBuilder.DropTable(
                name: "RegistroScout");

            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Gestiones");
        }
    }
}
