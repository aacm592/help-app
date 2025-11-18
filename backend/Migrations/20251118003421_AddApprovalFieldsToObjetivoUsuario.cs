using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddApprovalFieldsToObjetivoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DirigenteAproboId",
                table: "ObjetivosUsuario",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAprobacion",
                table: "ObjetivosUsuario",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaSeleccion",
                table: "ObjetivosUsuario",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_ObjetivosUsuario_DirigenteAproboId",
                table: "ObjetivosUsuario",
                column: "DirigenteAproboId");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjetivosUsuario_Users_DirigenteAproboId",
                table: "ObjetivosUsuario",
                column: "DirigenteAproboId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjetivosUsuario_Users_DirigenteAproboId",
                table: "ObjetivosUsuario");

            migrationBuilder.DropIndex(
                name: "IX_ObjetivosUsuario_DirigenteAproboId",
                table: "ObjetivosUsuario");

            migrationBuilder.DropColumn(
                name: "DirigenteAproboId",
                table: "ObjetivosUsuario");

            migrationBuilder.DropColumn(
                name: "FechaAprobacion",
                table: "ObjetivosUsuario");

            migrationBuilder.DropColumn(
                name: "FechaSeleccion",
                table: "ObjetivosUsuario");
        }
    }
}
