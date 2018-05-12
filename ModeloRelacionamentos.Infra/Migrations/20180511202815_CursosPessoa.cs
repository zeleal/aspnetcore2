using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ModeloRelacionamentos.Infra.Migrations
{
    public partial class CursosPessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CURSOS",
                schema: "dbo",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RUA = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CURSOS", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "CURSOSPESSOA",
                columns: table => new
                {
                    CODCRUSOS = table.Column<int>(nullable: false),
                    CODPESSOA = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CURSOSPESSOA", x => new { x.CODCRUSOS, x.CODPESSOA });
                    table.ForeignKey(
                        name: "FK_CURSOSPESSOA_CURSOS_CODCRUSOS",
                        column: x => x.CODCRUSOS,
                        principalSchema: "dbo",
                        principalTable: "CURSOS",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CURSOSPESSOA_PESSOA_CODPESSOA",
                        column: x => x.CODPESSOA,
                        principalSchema: "dbo",
                        principalTable: "PESSOA",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CURSOSPESSOA_CODPESSOA",
                table: "CURSOSPESSOA",
                column: "CODPESSOA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CURSOSPESSOA");

            migrationBuilder.DropTable(
                name: "CURSOS",
                schema: "dbo");
        }
    }
}
