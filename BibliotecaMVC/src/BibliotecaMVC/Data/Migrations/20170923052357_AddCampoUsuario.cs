using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaMVC.Data.Migrations
{
    public partial class AddCampoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Emprestimo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_ApplicationUserId",
                table: "Emprestimo",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimo_AspNetUsers_ApplicationUserId",
                table: "Emprestimo",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimo_AspNetUsers_ApplicationUserId",
                table: "Emprestimo");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimo_ApplicationUserId",
                table: "Emprestimo");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Emprestimo");
        }
    }
}
