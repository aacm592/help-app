using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class PermisosUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermisosTipo");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermisosUsers");

            migrationBuilder.CreateTable(
                name: "PermisosTipo",
                columns: table => new
                {
                    PermisosId = table.Column<int>(type: "integer", nullable: false),
                    TiposId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisosTipo", x => new { x.PermisosId, x.TiposId });
                    table.ForeignKey(
                        name: "FK_PermisosTipo_Permisos_PermisosId",
                        column: x => x.PermisosId,
                        principalTable: "Permisos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermisosTipo_Tipos_TiposId",
                        column: x => x.TiposId,
                        principalTable: "Tipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermisosTipo_TiposId",
                table: "PermisosTipo",
                column: "TiposId");
        }
    }
}
