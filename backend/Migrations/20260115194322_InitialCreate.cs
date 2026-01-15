using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreasCrecimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasCrecimiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Distritos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distritos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ramas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    EdadMinima = table.Column<int>(type: "integer", nullable: false),
                    EdadMaxima = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ramas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GruposScout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DistritoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposScout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GruposScout_Distritos_DistritoId",
                        column: x => x.DistritoId,
                        principalTable: "Distritos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RamaId = table.Column<int>(type: "integer", nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Nombre = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especialidades_Ramas_RamaId",
                        column: x => x.RamaId,
                        principalTable: "Ramas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EtapasProgresion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    RamaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtapasProgresion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EtapasProgresion_Ramas_RamaId",
                        column: x => x.RamaId,
                        principalTable: "Ramas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreUsuario = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Contrasena = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    TipoId = table.Column<int>(type: "integer", nullable: false),
                    PasswordResetToken = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    PasswordResetTokenExpiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Tipos_TipoId",
                        column: x => x.TipoId,
                        principalTable: "Tipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Codigo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    GrupoScoutId = table.Column<int>(type: "integer", nullable: false),
                    RamaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unidades_GruposScout_GrupoScoutId",
                        column: x => x.GrupoScoutId,
                        principalTable: "GruposScout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Unidades_Ramas_RamaId",
                        column: x => x.RamaId,
                        principalTable: "Ramas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitosEsp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EspecialidadId = table.Column<int>(type: "integer", nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitosEsp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequisitosEsp_Especialidades_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjetivosEducativos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    AreaCrecimientoId = table.Column<int>(type: "integer", nullable: false),
                    EtapaProgresionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetivosEducativos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjetivosEducativos_AreasCrecimiento_AreaCrecimientoId",
                        column: x => x.AreaCrecimientoId,
                        principalTable: "AreasCrecimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjetivosEducativos_EtapasProgresion_EtapaProgresionId",
                        column: x => x.EtapaProgresionId,
                        principalTable: "EtapasProgresion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermisosUsers",
                columns: table => new
                {
                    PermisosId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisosUsers", x => new { x.PermisosId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_PermisosUsers_Permisos_PermisosId",
                        column: x => x.PermisosId,
                        principalTable: "Permisos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermisosUsers_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Telf = table.Column<int>(type: "integer", nullable: false),
                    Ci = table.Column<int>(type: "integer", nullable: false),
                    ComplementoCi = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Genero = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnidadUsuario",
                columns: table => new
                {
                    UnidadesId = table.Column<int>(type: "integer", nullable: false),
                    UsuariosId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadUsuario", x => new { x.UnidadesId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_UnidadUsuario_Unidades_UnidadesId",
                        column: x => x.UnidadesId,
                        principalTable: "Unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnidadUsuario_Users_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitoEspUsers",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    RequisitoId = table.Column<int>(type: "integer", nullable: false),
                    FechaSeleccion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaAprobacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DirigenteAproboId = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitoEspUsers", x => new { x.RequisitoId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_RequisitoEspUsers_RequisitosEsp_RequisitoId",
                        column: x => x.RequisitoId,
                        principalTable: "RequisitosEsp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequisitoEspUsers_Users_DirigenteAproboId",
                        column: x => x.DirigenteAproboId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequisitoEspUsers_Users_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjetivosUsuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    ObjetivoEducativoId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    FechaSeleccion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaAprobacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DirigenteAproboId = table.Column<int>(type: "integer", nullable: true)
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
                        name: "FK_ObjetivosUsuario_Users_DirigenteAproboId",
                        column: x => x.DirigenteAproboId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ObjetivosUsuario_Users_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiriProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Profesion = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Ocupacion = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Cargo1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Cargo2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiriProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiriProfiles_UserProfiles_Id",
                        column: x => x.Id,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScoutProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    UnidadEducativa = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    Curso = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Etapa = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoutProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScoutProfiles_UserProfiles_Id",
                        column: x => x.Id,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                table: "Distritos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Beni" },
                    { 2, "Chuquisaca" },
                    { 3, "Cochabamba" },
                    { 4, "La Paz" },
                    { 5, "Oruro" },
                    { 6, "Potosi" },
                    { 7, "Santa Cruz" },
                    { 8, "Tarija" }
                });

            migrationBuilder.InsertData(
                table: "Ramas",
                columns: new[] { "Id", "EdadMaxima", "EdadMinima", "Nombre" },
                values: new object[,]
                {
                    { 1, 11, 7, "Lobatos" },
                    { 2, 15, 11, "Exploradores" },
                    { 3, 18, 15, "Pioneros" },
                    { 4, 21, 18, "Rovers" }
                });

            migrationBuilder.InsertData(
                table: "Tipos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Scout" },
                    { 2, "Dirigente" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_RamaId",
                table: "Especialidades",
                column: "RamaId");

            migrationBuilder.CreateIndex(
                name: "IX_EtapasProgresion_RamaId",
                table: "EtapasProgresion",
                column: "RamaId");

            migrationBuilder.CreateIndex(
                name: "IX_GruposScout_DistritoId",
                table: "GruposScout",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetivosEducativos_AreaCrecimientoId",
                table: "ObjetivosEducativos",
                column: "AreaCrecimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetivosEducativos_EtapaProgresionId",
                table: "ObjetivosEducativos",
                column: "EtapaProgresionId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetivosUsuario_DirigenteAproboId",
                table: "ObjetivosUsuario",
                column: "DirigenteAproboId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetivosUsuario_ObjetivoEducativoId",
                table: "ObjetivosUsuario",
                column: "ObjetivoEducativoId");

            migrationBuilder.CreateIndex(
                name: "IX_PermisosUsers_UsersId",
                table: "PermisosUsers",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitoEspUsers_DirigenteAproboId",
                table: "RequisitoEspUsers",
                column: "DirigenteAproboId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitoEspUsers_UsuarioId",
                table: "RequisitoEspUsers",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitosEsp_EspecialidadId",
                table: "RequisitosEsp",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_GrupoScoutId",
                table: "Unidades",
                column: "GrupoScoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_RamaId",
                table: "Unidades",
                column: "RamaId");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadUsuario_UsuariosId",
                table: "UnidadUsuario",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TipoId",
                table: "Users",
                column: "TipoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiriProfiles");

            migrationBuilder.DropTable(
                name: "ObjetivosUsuario");

            migrationBuilder.DropTable(
                name: "PermisosUsers");

            migrationBuilder.DropTable(
                name: "RequisitoEspUsers");

            migrationBuilder.DropTable(
                name: "ScoutProfiles");

            migrationBuilder.DropTable(
                name: "UnidadUsuario");

            migrationBuilder.DropTable(
                name: "ObjetivosEducativos");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "RequisitosEsp");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropTable(
                name: "AreasCrecimiento");

            migrationBuilder.DropTable(
                name: "EtapasProgresion");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "GruposScout");

            migrationBuilder.DropTable(
                name: "Ramas");

            migrationBuilder.DropTable(
                name: "Tipos");

            migrationBuilder.DropTable(
                name: "Distritos");
        }
    }
}
