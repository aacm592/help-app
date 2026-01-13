using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "UserProfiles",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(60)",
                oldMaxLength: 60);

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "UserProfiles",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Ci",
                table: "UserProfiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ComplementoCi",
                table: "UserProfiles",
                type: "character varying(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserProfiles",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "UserProfiles",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Telf",
                table: "UserProfiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DiriProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Profesion = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Ocupacion = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
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
                    UnidadEducativa = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Curso = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiriProfiles");

            migrationBuilder.DropTable(
                name: "ScoutProfiles");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Ci",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "ComplementoCi",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Telf",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "UserProfiles",
                type: "character varying(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);
        }
    }
}
