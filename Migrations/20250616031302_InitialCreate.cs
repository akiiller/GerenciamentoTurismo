using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoTurismo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PacotesTuristicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CapacidadeMaxima = table.Column<int>(type: "INTEGER", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacotesTuristicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaisesDestino",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaisesDestino", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataReserva = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    PacoteTuristicoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_PacotesTuristicos_PacoteTuristicoId",
                        column: x => x.PacoteTuristicoId,
                        principalTable: "PacotesTuristicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CidadesDestino",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PaisDestinoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CidadesDestino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CidadesDestino_PaisesDestino_PaisDestinoId",
                        column: x => x.PaisDestinoId,
                        principalTable: "PaisesDestino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacotesDestinos",
                columns: table => new
                {
                    PacoteTuristicoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CidadeDestinoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacotesDestinos", x => new { x.PacoteTuristicoId, x.CidadeDestinoId });
                    table.ForeignKey(
                        name: "FK_PacotesDestinos_CidadesDestino_CidadeDestinoId",
                        column: x => x.CidadeDestinoId,
                        principalTable: "CidadesDestino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacotesDestinos_PacotesTuristicos_PacoteTuristicoId",
                        column: x => x.PacoteTuristicoId,
                        principalTable: "PacotesTuristicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CidadesDestino_PaisDestinoId",
                table: "CidadesDestino",
                column: "PaisDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Email",
                table: "Clientes",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PacotesDestinos_CidadeDestinoId",
                table: "PacotesDestinos",
                column: "CidadeDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_PaisesDestino_Nome",
                table: "PaisesDestino",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ClienteId",
                table: "Reservas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_PacoteTuristicoId",
                table: "Reservas",
                column: "PacoteTuristicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PacotesDestinos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "CidadesDestino");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "PacotesTuristicos");

            migrationBuilder.DropTable(
                name: "PaisesDestino");
        }
    }
}
