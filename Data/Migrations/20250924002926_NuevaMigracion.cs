using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace proyectoIngSoft.Data.Migrations
{
    /// <inheritdoc />
    public partial class NuevaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_DocumentoMedico",
                columns: table => new
                {
                    IdArchivo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Tamaño = table.Column<long>(type: "bigint", nullable: false),
                    FechaSubida = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Archivo = table.Column<byte[]>(type: "bytea", nullable: false),
                    DescansoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_DocumentoMedico", x => x.IdArchivo);
                    table.ForeignKey(
                        name: "FK_t_DocumentoMedico_t_Descanso_DescansoId",
                        column: x => x.DescansoId,
                        principalTable: "t_Descanso",
                        principalColumn: "IdDescanso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_DocumentoMedico_DescansoId",
                table: "t_DocumentoMedico",
                column: "DescansoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_DocumentoMedico");
        }
    }
}
