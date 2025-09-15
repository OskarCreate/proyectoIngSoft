using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoIngSoft.Data.Migrations
{
    /// <inheritdoc />
    public partial class primeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_registrar_descanso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DNIPaciente = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    FechaAtencion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NombreDoctor = table.Column<string>(type: "TEXT", nullable: false),
                    CodigoAtencion = table.Column<string>(type: "TEXT", nullable: false),
                    RazonDescanso = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_registrar_descanso", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_registrar_descanso");
        }
    }
}
