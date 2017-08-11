using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BibliotecaMVC.Data.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sistema",
                columns: table => new
                {
                    SistemaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sistema", x => x.SistemaID);
                });

            migrationBuilder.CreateTable(
                name: "SistemaUsuario",
                columns: table => new
                {
                    SistemaID = table.Column<int>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemaUsuario", x => new { x.SistemaID, x.UsuarioID });
                    table.ForeignKey(
                        name: "FK_SistemaUsuario_Sistema_SistemaID",
                        column: x => x.SistemaID,
                        principalTable: "Sistema",
                        principalColumn: "SistemaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SistemaUsuario_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SistemaUsuario_SistemaID",
                table: "SistemaUsuario",
                column: "SistemaID");

            migrationBuilder.CreateIndex(
                name: "IX_SistemaUsuario_UsuarioID",
                table: "SistemaUsuario",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SistemaUsuario");

            migrationBuilder.DropTable(
                name: "Sistema");
        }
    }
}
