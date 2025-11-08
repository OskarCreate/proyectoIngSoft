using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoIngSoft.Data.Migrations
{
    /// <inheritdoc />
    public partial class estadoprocesadoMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EstadoProcesado",
                table: "t_Descanso",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoProcesado",
                table: "t_Descanso");
        }
    }
}
