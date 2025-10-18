using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace proyectoIngSoft.Data.Migrations
{
    /// <inheritdoc />
    public partial class razonsocialMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RazonSocial",
                table: "T_Usuarios",
                type: "character varying(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCodigo",
                table: "T_Usuarios",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DbSetCodigoSocial",
                columns: table => new
                {
                    IdCodigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    Rol = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSetCodigoSocial", x => x.IdCodigo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Usuarios_IdCodigo",
                table: "T_Usuarios",
                column: "IdCodigo");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Usuarios_DbSetCodigoSocial_IdCodigo",
                table: "T_Usuarios",
                column: "IdCodigo",
                principalTable: "DbSetCodigoSocial",
                principalColumn: "IdCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Usuarios_DbSetCodigoSocial_IdCodigo",
                table: "T_Usuarios");

            migrationBuilder.DropTable(
                name: "DbSetCodigoSocial");

            migrationBuilder.DropIndex(
                name: "IX_T_Usuarios_IdCodigo",
                table: "T_Usuarios");

            migrationBuilder.DropColumn(
                name: "IdCodigo",
                table: "T_Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "RazonSocial",
                table: "T_Usuarios",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(6)",
                oldMaxLength: 6);
        }
    }
}
