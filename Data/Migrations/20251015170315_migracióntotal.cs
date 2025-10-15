using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace proyectoIngSoft.Data.Migrations
{
    /// <inheritdoc />
    public partial class migracióntotal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Mensaje = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Detalle = table.Column<string>(type: "text", nullable: false),
                    DocumentoAdjuntos = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_Accidente",
                columns: table => new
                {
                    IdAccidente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreComp = table.Column<string>(type: "text", nullable: false),
                    DNI = table.Column<int>(type: "integer", nullable: false),
                    FechaIni = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: false),
                    Observaciones = table.Column<string>(type: "text", nullable: false),
                    TipoDM = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Accidente", x => x.IdAccidente);
                });

            migrationBuilder.CreateTable(
                name: "t_Enfermedad",
                columns: table => new
                {
                    IdEnfermedad = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubtipoSol = table.Column<string>(type: "text", nullable: false),
                    FechaIni = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: false),
                    NombreMedi = table.Column<string>(type: "text", nullable: false),
                    CentroMedico = table.Column<string>(type: "text", nullable: false),
                    DiasDesc = table.Column<int>(type: "integer", nullable: false),
                    Diagnostico = table.Column<string>(type: "text", nullable: false),
                    DescEnfe = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Enfermedad", x => x.IdEnfermedad);
                });

            migrationBuilder.CreateTable(
                name: "t_EnfermedadFamiliar",
                columns: table => new
                {
                    IdEnfermedadFam = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreFamiliar = table.Column<string>(type: "text", nullable: false),
                    FechaIni = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: false),
                    Parentesco = table.Column<string>(type: "text", nullable: false),
                    CentroMedico = table.Column<string>(type: "text", nullable: false),
                    Medico = table.Column<string>(type: "text", nullable: false),
                    NumeroCMP = table.Column<string>(type: "text", nullable: false),
                    FechaDiag = table.Column<DateOnly>(type: "date", nullable: false),
                    DiaSoli = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_EnfermedadFamiliar", x => x.IdEnfermedadFam);
                });

            migrationBuilder.CreateTable(
                name: "t_Fallecimiento",
                columns: table => new
                {
                    IdFallec = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreFallec = table.Column<string>(type: "text", nullable: false),
                    FechaIni = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: false),
                    Parentesco = table.Column<string>(type: "text", nullable: false),
                    FechaComun = table.Column<DateOnly>(type: "date", nullable: false),
                    LugarSep = table.Column<string>(type: "text", nullable: false),
                    Traslado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Fallecimiento", x => x.IdFallec);
                });

            migrationBuilder.CreateTable(
                name: "t_Maternidad",
                columns: table => new
                {
                    IdMater = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaParto = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaIni = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: false),
                    SemanasGest = table.Column<int>(type: "integer", nullable: false),
                    PartoMult = table.Column<string>(type: "text", nullable: false),
                    FechaUltM = table.Column<DateOnly>(type: "date", nullable: false),
                    CentroMed = table.Column<string>(type: "text", nullable: false),
                    MedicoT = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Maternidad", x => x.IdMater);
                });

            migrationBuilder.CreateTable(
                name: "t_Paternidad",
                columns: table => new
                {
                    IdPater = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaParto = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaIni = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: false),
                    NombrePareja = table.Column<string>(type: "text", nullable: false),
                    TipoSituacion = table.Column<string>(type: "text", nullable: false),
                    CentroMed = table.Column<string>(type: "text", nullable: false),
                    FechaComun = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Paternidad", x => x.IdPater);
                });

            migrationBuilder.CreateTable(
                name: "t_TiposDescanso",
                columns: table => new
                {
                    IdTDescanso = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_TiposDescanso", x => x.IdTDescanso);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Apellidos = table.Column<string>(type: "text", nullable: false),
                    Dni = table.Column<string>(type: "text", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false),
                    Ubigeo = table.Column<string>(type: "text", nullable: false),
                    Distrito = table.Column<string>(type: "text", nullable: false),
                    RazonSocial = table.Column<string>(type: "text", nullable: true),
                    CargoLaboral = table.Column<string>(type: "text", nullable: true),
                    ConfirmarPassword = table.Column<string>(type: "text", nullable: false),
                    Rol = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "ValidarDatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DNI = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    Ubigeo = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    Captcha = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidarDatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_Descanso",
                columns: table => new
                {
                    IdDescanso = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TipoDescansoId = table.Column<int>(type: "integer", nullable: false),
                    FechaIni = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AccidenteId = table.Column<int>(type: "integer", nullable: true),
                    MaternidadId = table.Column<int>(type: "integer", nullable: true),
                    PaternidadId = table.Column<int>(type: "integer", nullable: true),
                    EnfermedadId = table.Column<int>(type: "integer", nullable: true),
                    FallecimientoId = table.Column<int>(type: "integer", nullable: true),
                    EnfermedadFamId = table.Column<int>(type: "integer", nullable: true),
                    EstadoESSALUD = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EstadoSubsidioA = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Descanso", x => x.IdDescanso);
                    table.ForeignKey(
                        name: "FK_t_Descanso_Usuarios_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuarios",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_Descanso_t_Accidente_AccidenteId",
                        column: x => x.AccidenteId,
                        principalTable: "t_Accidente",
                        principalColumn: "IdAccidente");
                    table.ForeignKey(
                        name: "FK_t_Descanso_t_EnfermedadFamiliar_EnfermedadFamId",
                        column: x => x.EnfermedadFamId,
                        principalTable: "t_EnfermedadFamiliar",
                        principalColumn: "IdEnfermedadFam");
                    table.ForeignKey(
                        name: "FK_t_Descanso_t_Enfermedad_EnfermedadId",
                        column: x => x.EnfermedadId,
                        principalTable: "t_Enfermedad",
                        principalColumn: "IdEnfermedad");
                    table.ForeignKey(
                        name: "FK_t_Descanso_t_Fallecimiento_FallecimientoId",
                        column: x => x.FallecimientoId,
                        principalTable: "t_Fallecimiento",
                        principalColumn: "IdFallec");
                    table.ForeignKey(
                        name: "FK_t_Descanso_t_Maternidad_MaternidadId",
                        column: x => x.MaternidadId,
                        principalTable: "t_Maternidad",
                        principalColumn: "IdMater");
                    table.ForeignKey(
                        name: "FK_t_Descanso_t_Paternidad_PaternidadId",
                        column: x => x.PaternidadId,
                        principalTable: "t_Paternidad",
                        principalColumn: "IdPater");
                    table.ForeignKey(
                        name: "FK_t_Descanso_t_TiposDescanso_TipoDescansoId",
                        column: x => x.TipoDescansoId,
                        principalTable: "t_TiposDescanso",
                        principalColumn: "IdTDescanso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentosMedicos",
                columns: table => new
                {
                    IdDocumento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescansoId = table.Column<int>(type: "integer", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Tamaño = table.Column<long>(type: "bigint", nullable: false),
                    FechaSubida = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Archivo = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentosMedicos", x => x.IdDocumento);
                    table.ForeignKey(
                        name: "FK_DocumentosMedicos_t_Descanso_DescansoId",
                        column: x => x.DescansoId,
                        principalTable: "t_Descanso",
                        principalColumn: "IdDescanso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "t_TiposDescanso",
                columns: new[] { "IdTDescanso", "Nombre" },
                values: new object[,]
                {
                    { 1, "Enfermedad" },
                    { 2, "Maternidad" },
                    { 3, "Paternidad" },
                    { 4, "Fallecimiento Familiar" },
                    { 5, "Enfermedad Familiar" },
                    { 6, "Accidente" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosMedicos_DescansoId",
                table: "DocumentosMedicos",
                column: "DescansoId");

            migrationBuilder.CreateIndex(
                name: "IX_t_Descanso_AccidenteId",
                table: "t_Descanso",
                column: "AccidenteId");

            migrationBuilder.CreateIndex(
                name: "IX_t_Descanso_EnfermedadFamId",
                table: "t_Descanso",
                column: "EnfermedadFamId");

            migrationBuilder.CreateIndex(
                name: "IX_t_Descanso_EnfermedadId",
                table: "t_Descanso",
                column: "EnfermedadId");

            migrationBuilder.CreateIndex(
                name: "IX_t_Descanso_FallecimientoId",
                table: "t_Descanso",
                column: "FallecimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_t_Descanso_MaternidadId",
                table: "t_Descanso",
                column: "MaternidadId");

            migrationBuilder.CreateIndex(
                name: "IX_t_Descanso_PaternidadId",
                table: "t_Descanso",
                column: "PaternidadId");

            migrationBuilder.CreateIndex(
                name: "IX_t_Descanso_TipoDescansoId",
                table: "t_Descanso",
                column: "TipoDescansoId");

            migrationBuilder.CreateIndex(
                name: "IX_t_Descanso_UserId",
                table: "t_Descanso",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DocumentosMedicos");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ValidarDatos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "t_Descanso");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "t_Accidente");

            migrationBuilder.DropTable(
                name: "t_EnfermedadFamiliar");

            migrationBuilder.DropTable(
                name: "t_Enfermedad");

            migrationBuilder.DropTable(
                name: "t_Fallecimiento");

            migrationBuilder.DropTable(
                name: "t_Maternidad");

            migrationBuilder.DropTable(
                name: "t_Paternidad");

            migrationBuilder.DropTable(
                name: "t_TiposDescanso");
        }
    }
}
