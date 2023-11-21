using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrabalhoBancoDeDados.api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Universidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blocos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UniversidadeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blocos_Universidades_UniversidadeId",
                        column: x => x.UniversidadeId,
                        principalTable: "Universidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    BlocoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salas_Blocos_BlocoId",
                        column: x => x.BlocoId,
                        principalTable: "Blocos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Universidades",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Univali" },
                    { 2, "Uniavan" }
                });

            migrationBuilder.InsertData(
                table: "Blocos",
                columns: new[] { "Id", "Name", "UniversidadeId" },
                values: new object[,]
                {
                    { 1, "A", 1 },
                    { 2, "B", 1 },
                    { 3, "C", 1 },
                    { 4, "1", 2 },
                    { 5, "2", 2 },
                    { 6, "3", 2 }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "Id", "BlocoId", "Number" },
                values: new object[,]
                {
                    { 1, 1, 101 },
                    { 2, 1, 102 },
                    { 3, 2, 201 },
                    { 4, 2, 202 },
                    { 5, 3, 301 },
                    { 6, 3, 302 },
                    { 7, 4, 401 },
                    { 8, 4, 402 },
                    { 9, 5, 501 },
                    { 10, 5, 502 },
                    { 11, 6, 601 },
                    { 12, 6, 602 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blocos_UniversidadeId",
                table: "Blocos",
                column: "UniversidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Salas_BlocoId",
                table: "Salas",
                column: "BlocoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Blocos");

            migrationBuilder.DropTable(
                name: "Universidades");
        }
    }
}
