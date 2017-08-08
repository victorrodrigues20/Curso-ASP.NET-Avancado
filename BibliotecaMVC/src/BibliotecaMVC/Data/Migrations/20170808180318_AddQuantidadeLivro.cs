using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaMVC.Data.Migrations
{
    public partial class AddQuantidadeLivro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Livro",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Livro",
                maxLength: 200,
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Livro");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Livro",
                nullable: true);
        }
    }
}
