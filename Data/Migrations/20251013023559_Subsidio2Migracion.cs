using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoIngSoft.Data.Migrations
{
    /// <inheritdoc />
    public partial class Subsidio2Migracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EstadoSubsidioJ",
                table: "t_Descanso",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoSubsidioJ",
                table: "t_Descanso");
        }
    }
}
