using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoIngSoft.Data.Migrations
{
    /// <inheritdoc />
    public partial class fechaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaFin",
                table: "t_Paternidad",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaIni",
                table: "t_Paternidad",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaFin",
                table: "t_Maternidad",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaIni",
                table: "t_Maternidad",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaFin",
                table: "t_Fallecimiento",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaIni",
                table: "t_Fallecimiento",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaFin",
                table: "t_EnfermedadFamiliar",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaIni",
                table: "t_EnfermedadFamiliar",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "t_Paternidad");

            migrationBuilder.DropColumn(
                name: "FechaIni",
                table: "t_Paternidad");

            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "t_Maternidad");

            migrationBuilder.DropColumn(
                name: "FechaIni",
                table: "t_Maternidad");

            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "t_Fallecimiento");

            migrationBuilder.DropColumn(
                name: "FechaIni",
                table: "t_Fallecimiento");

            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "t_EnfermedadFamiliar");

            migrationBuilder.DropColumn(
                name: "FechaIni",
                table: "t_EnfermedadFamiliar");
        }
    }
}
