using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataContexto.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CURSOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CURSOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ALUNOS",
                columns: table => new
                {
                    IdCursos = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALUNOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ALUNOS_CURSOS_IdCursos",
                        column: x => x.IdCursos,
                        principalTable: "CURSOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALUNOS_IdCursos",
                table: "ALUNOS",
                column: "IdCursos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALUNOS");

            migrationBuilder.DropTable(
                name: "CURSOS");
        }
    }
}
