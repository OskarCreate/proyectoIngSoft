using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoIngSoft.Data.Migrations
{
    /// <inheritdoc />
    public partial class segundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_Accidente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreComp = table.Column<string>(type: "TEXT", nullable: false),
                    DNI = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaIni = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Observaciones = table.Column<string>(type: "TEXT", nullable: false),
                    TipoDM = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Accidente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_Enfermedad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubtipoSol = table.Column<string>(type: "TEXT", nullable: false),
                    FechaIni = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NombreMedi = table.Column<string>(type: "TEXT", nullable: false),
                    CentroMedico = table.Column<string>(type: "TEXT", nullable: false),
                    DiasDesc = table.Column<int>(type: "INTEGER", nullable: false),
                    Diagnostico = table.Column<string>(type: "TEXT", nullable: false),
                    DescEnfe = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Enfermedad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_EnfermedadFamiliar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreFamiliar = table.Column<string>(type: "TEXT", nullable: false),
                    Parentesco = table.Column<string>(type: "TEXT", nullable: false),
                    CentroMedico = table.Column<string>(type: "TEXT", nullable: false),
                    Medico = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroCMP = table.Column<string>(type: "TEXT", nullable: false),
                    FechaDiag = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DiaSoli = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_EnfermedadFamiliar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_Fallecimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreFallec = table.Column<int>(type: "INTEGER", nullable: false),
                    Parentesco = table.Column<string>(type: "TEXT", nullable: false),
                    FechaComun = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LugarSep = table.Column<string>(type: "TEXT", nullable: false),
                    Traslado = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Fallecimiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_Maternidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaParto = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SemanasGest = table.Column<int>(type: "INTEGER", nullable: false),
                    PartoMult = table.Column<string>(type: "TEXT", nullable: false),
                    FechaUltM = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CentroMed = table.Column<string>(type: "TEXT", nullable: false),
                    MedicoT = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Maternidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_Paternidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaParto = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NombrePareja = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoSituacion = table.Column<string>(type: "TEXT", nullable: false),
                    CentroMed = table.Column<string>(type: "TEXT", nullable: false),
                    FechaComun = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Paternidad", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_Accidente");

            migrationBuilder.DropTable(
                name: "t_Enfermedad");

            migrationBuilder.DropTable(
                name: "t_EnfermedadFamiliar");

            migrationBuilder.DropTable(
                name: "t_Fallecimiento");

            migrationBuilder.DropTable(
                name: "t_Maternidad");

            migrationBuilder.DropTable(
                name: "t_Paternidad");
        }
    }
}
