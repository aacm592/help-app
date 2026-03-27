using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class permisosUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermisosUsers");

            migrationBuilder.CreateTable(
                name: "UserPermisos",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PermisoId = table.Column<int>(type: "integer", nullable: false),
                    GrupoScoutId = table.Column<int>(type: "integer", nullable: false),
                    DistritoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermisos", x => new { x.UserId, x.PermisoId, x.GrupoScoutId, x.DistritoId });
                    table.ForeignKey(
                        name: "FK_UserPermisos_Distritos_DistritoId",
                        column: x => x.DistritoId,
                        principalTable: "Distritos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPermisos_GruposScout_GrupoScoutId",
                        column: x => x.GrupoScoutId,
                        principalTable: "GruposScout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPermisos_Permisos_PermisoId",
                        column: x => x.PermisoId,
                        principalTable: "Permisos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPermisos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Responsable de grupo" },
                    { 2, "Administrador de grupo" },
                    { 3, "Director de distrito" },
                    { 4, "Administrador de distrito" },
                    { 5, "Miembro del equipo distrital" },
                    { 6, "Miembro del equipo nacional" },
                    { 7, "Administrador nacional" },
                    { 8, "Ejecutivo nacional" },
                    { 9, "Jefe scout nacional" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPermisos_DistritoId",
                table: "UserPermisos",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermisos_GrupoScoutId",
                table: "UserPermisos",
                column: "GrupoScoutId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermisos_PermisoId",
                table: "UserPermisos",
                column: "PermisoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPermisos");

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 9);

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

            migrationBuilder.CreateIndex(
                name: "IX_PermisosUsers_UsersId",
                table: "PermisosUsers",
                column: "UsersId");
        }
    }
}
