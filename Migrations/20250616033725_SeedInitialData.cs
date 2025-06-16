using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GerenciamentoTurismo.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PaisesDestino",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Brasil" },
                    { 2, "Itália" },
                    { 3, "França" },
                    { 4, "Estados Unidos" }
                });

            migrationBuilder.InsertData(
                table: "CidadesDestino",
                columns: new[] { "Id", "Nome", "PaisDestinoId" },
                values: new object[,]
                {
                    { 101, "Rio de Janeiro", 1 },
                    { 102, "Salvador", 1 },
                    { 201, "Roma", 2 },
                    { 202, "Veneza", 2 },
                    { 301, "Paris", 3 },
                    { 401, "Nova York", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CidadesDestino",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "CidadesDestino",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "CidadesDestino",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "CidadesDestino",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "CidadesDestino",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "CidadesDestino",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "PaisesDestino",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaisesDestino",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaisesDestino",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PaisesDestino",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
