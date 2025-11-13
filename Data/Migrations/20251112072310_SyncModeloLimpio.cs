using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoIngSoft.Data.Migrations
{
    /// <inheritdoc />
    public partial class SyncModeloLimpio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "t_Paternidad",
                type: "text",
                nullable: false,
                defaultValue: "");

            // migrationBuilder.AddColumn<string>(
            //     name: "Motivo",
            //     table: "t_Fallecimiento",
            //     type: "text",
            //     nullable: false,
            //     defaultValue: "");

            // migrationBuilder.AddColumn<string>(
            //     name: "CodigoEssalud",
            //     table: "t_EnfermedadFamiliar",
            //     type: "text",
            //     nullable: true);

            // migrationBuilder.AddColumn<string>(
            //     name: "CodigoEssalud",
            //     table: "t_Enfermedad",
            //     type: "text",
            //     nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "T_CalendarioEventos",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "DocumentosMedicos",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "t_Paternidad");

            migrationBuilder.DropColumn(
                name: "Motivo",
                table: "t_Fallecimiento");

            migrationBuilder.DropColumn(
                name: "CodigoEssalud",
                table: "t_EnfermedadFamiliar");

            migrationBuilder.DropColumn(
                name: "CodigoEssalud",
                table: "t_Enfermedad");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "T_CalendarioEventos",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "DocumentosMedicos",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);
        }
    }
}
