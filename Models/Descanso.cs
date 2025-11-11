using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoIngSoft.Models
{
    [Table("t_Descanso")]
    public class Descanso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDescanso { get; set; }

        // Relación con User
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        // Relación con TipoDescanso
        [Required]
        public int TipoDescansoId { get; set; }
        public TipoDescanso TipoDescanso { get; set; }

        // Fechas principales
        [Required]
        public DateTime FechaIni { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        [Required]
        public DateTime FechaSolicitud { get; set; }

        // FKs opcionales según el tipo de descanso
        public int? AccidenteId { get; set; }
        public Accidente? Accidente { get; set; }

        public int? MaternidadId { get; set; }
        public Maternidad? Maternidad { get; set; }

        public int? PaternidadId { get; set; }
        public Paternidad? Paternidad { get; set; }

        public int? EnfermedadId { get; set; }
        public Enfermedad? Enfermedad { get; set; }

        public int? FallecimientoId { get; set; }
        public Fallecimiento? Fallecimiento { get; set; }

        public int? EnfermedadFamId { get; set; }
        public EnfermedadFam? EnfermedadFam { get; set; }

        public ICollection<DocumentoMedico> DocumentosMedicos { get; set; } = new List<DocumentoMedico>();

        // Estados
        [StringLength(50)]
        public string EstadoESSALUD { get; set; } = "En Proceso";

        [StringLength(50)]
        public string EstadoSubsidioA { get; set; } = "Descanso Activo";

        [StringLength(50)]
        public string EstadoSubsidioJ { get; set; } = "Pendiente";

        public string EstadoProcesado { get; set; }

        // 🔹 Propiedades calculadas y de apoyo para vistas/modales
        [NotMapped]
        public int DiasTotales => (FechaFin - FechaIni).Days + 1;

        [NotMapped]
        public int DiasTranscurridos => (DateTime.Now - FechaIni).Days;

        [NotMapped]
        public string RazonDescanso =>
            Accidente?.Observaciones
            ?? Maternidad?.Descripcion
            ?? Paternidad?.Descripcion
            ?? Enfermedad?.DescEnfe
            ?? Fallecimiento?.Motivo
            ?? EnfermedadFam?.NombreFamiliar
            ?? "N/A";

        [NotMapped]
        public string DiagnosticoDescanso =>
            Enfermedad?.Diagnostico
            ?? Accidente?.TipoDM
            ?? EnfermedadFam?.FechaDiag.ToString("dd/MM/yyyy")
            ?? string.Empty;

        [NotMapped]
        public string CodigoEssalud =>
            Enfermedad?.CodigoEssalud
            ?? EnfermedadFam?.CodigoEssalud
            ?? string.Empty;

        // Información médica
        [NotMapped]
        public string CentroMedicoDescanso =>
            Enfermedad?.CentroMedico
            ?? EnfermedadFam?.CentroMedico
            ?? string.Empty;

        [NotMapped]
        public string MedicoTratanteDescanso =>
            Enfermedad?.NombreMedi
            ?? EnfermedadFam?.Medico
            ?? string.Empty;

        [NotMapped]
        public string CMPDescanso =>
            EnfermedadFam?.NumeroCMP ?? string.Empty;

        // Información del trabajador (relacionada con User)
        [NotMapped]
        public string NombreCompleto => $"{User?.Username ?? ""} {User?.Apellidos ?? ""}";

        [NotMapped]
        public string DNI => User?.Dni ?? "";

        [NotMapped]
        public string Email => User?.Email ?? "";

        [NotMapped]
        public string Telefono => User?.Telefono ?? "";

        [NotMapped]
        public string CargoDescanso => User?.CargoLaboral ?? "";

        [NotMapped]
        public string AreaDescanso => ""; // No existe en User, se deja vacío
    }
}
