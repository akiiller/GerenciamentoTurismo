using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GerenciamentoTurismo.Migrations
{
    /// <inheritdoc />
    public partial class SeedPacotesTuristicos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PacotesTuristicos",
                columns: new[] { "Id", "CapacidadeMaxima", "DataInicio", "Preco", "Titulo" },
                values: new object[,]
                {
                    { 1, 50, new DateTime(2026, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4500.00m, "Carnaval no Brasil" },
                    { 2, 30, new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 7800.00m, "Tour Europeu Clássico" },
                    { 3, 25, new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6200.00m, "Aventura na Big Apple" }
                });

            migrationBuilder.InsertData(
                table: "PacotesDestinos",
                columns: new[] { "CidadeDestinoId", "PacoteTuristicoId" },
                values: new object[,]
                {
                    { 101, 1 },
                    { 102, 1 },
                    { 201, 2 },
                    { 301, 2 },
                    { 401, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PacotesDestinos",
                keyColumns: new[] { "CidadeDestinoId", "PacoteTuristicoId" },
                keyValues: new object[] { 101, 1 });

            migrationBuilder.DeleteData(
                table: "PacotesDestinos",
                keyColumns: new[] { "CidadeDestinoId", "PacoteTuristicoId" },
                keyValues: new object[] { 102, 1 });

            migrationBuilder.DeleteData(
                table: "PacotesDestinos",
                keyColumns: new[] { "CidadeDestinoId", "PacoteTuristicoId" },
                keyValues: new object[] { 201, 2 });

            migrationBuilder.DeleteData(
                table: "PacotesDestinos",
                keyColumns: new[] { "CidadeDestinoId", "PacoteTuristicoId" },
                keyValues: new object[] { 301, 2 });

            migrationBuilder.DeleteData(
                table: "PacotesDestinos",
                keyColumns: new[] { "CidadeDestinoId", "PacoteTuristicoId" },
                keyValues: new object[] { 401, 3 });

            migrationBuilder.DeleteData(
                table: "PacotesTuristicos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PacotesTuristicos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PacotesTuristicos",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
