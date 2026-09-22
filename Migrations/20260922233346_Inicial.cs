using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeskFlow.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chamado",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TituloChamado = table.Column<string>(type: "varchar(250)", nullable: false),
                    DescricaoChamado = table.Column<string>(type: "varchar(500)", nullable: false),
                    PrioridadeChamado = table.Column<string>(type: "varchar(50)", nullable: false),
                    StatusChamado = table.Column<string>(type: "varchar(50)", nullable: false),
                    SolicitanteChamado = table.Column<string>(type: "varchar(150)", nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFechamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SolucaoChamado = table.Column<string>(type: "varchar(500)", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<string>(type: "varchar(50)", nullable: false),
                    NomeCategoria = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Categoria", x => x.IdCategoria);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chamado");

            migrationBuilder.DropTable(
                name: "Tb_Categoria");
        }
    }
}
