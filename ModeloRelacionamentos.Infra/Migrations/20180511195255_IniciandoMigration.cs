using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ModeloRelacionamentos.Infra.Migrations
{
    public partial class IniciandoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "PESSOA",
                schema: "dbo",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime", nullable: false),
                    NOME = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOA", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "ENDERECO",
                schema: "dbo",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoPessoa = table.Column<int>(nullable: false),
                    NUMERO = table.Column<int>(type: "int", nullable: false),
                    RUA = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_ENDERECO_PESSOA_CodigoPessoa",
                        column: x => x.CodigoPessoa,
                        principalSchema: "dbo",
                        principalTable: "PESSOA",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FILHOS",
                schema: "dbo",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CODIGOPAI = table.Column<int>(nullable: true),
                    NOME = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FILHOS", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_FILHOS_PESSOA_CODIGOPAI",
                        column: x => x.CODIGOPAI,
                        principalSchema: "dbo",
                        principalTable: "PESSOA",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_CodigoPessoa",
                schema: "dbo",
                table: "ENDERECO",
                column: "CodigoPessoa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FILHOS_CODIGOPAI",
                schema: "dbo",
                table: "FILHOS",
                column: "CODIGOPAI");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ENDERECO",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FILHOS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PESSOA",
                schema: "dbo");
        }
    }
}
