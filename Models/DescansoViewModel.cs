using System;
using System.Collections.Generic;
using System.Linq;

namespace proyectoIngSoft.Models

{
    // ViewModel para la vista principal HU15
    public class DescansoViewModel
    {
        public int IdDescanso { get; set; }
        public string DNI { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string RazonDescanso { get; set; } = string.Empty;
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public int DiasTotales => (int)(FechaFin - FechaIni).TotalDays + 1; // +1 para incluir el día inicial
        public string EstadoSubsidioA { get; set; } = string.Empty;

        // Documentos asociados a este descanso
        public List<DocumentoMedico> DocumentosMedicos { get; set; } = new List<DocumentoMedico>();

        // Computadas
        public int TotalDocumentos => DocumentosMedicos?.Count ?? 0;

        // Para detectar documentos incompletos según tipo de descanso
        public List<string> DocumentosFaltantes()
        {
            var requeridos = new List<string>();
            switch (TipoDescansoId)
            {
                case 1: // Enfermedad
                    requeridos.Add("CertificadoMedico.pdf");
                    break;
                case 2: // Maternidad
                    requeridos.Add("CertificadoMaternidad.pdf");
                    break;
                case 3: // Paternidad
                    requeridos.Add("CertificadoPaternidad.pdf");
                    break;
                default:
                    break;
            }

            var subidos = DocumentosMedicos?.Select(d => d.Nombre).ToList() ?? new List<string>();
            return requeridos.Except(subidos).ToList();
        }

        public int TipoDescansoId { get; set; }

        // Detectar duplicados
        public List<string> DocumentosDuplicados()
        {
            if (DocumentosMedicos == null) return new List<string>();
            return DocumentosMedicos
                   .GroupBy(d => d.Nombre)
                   .Where(g => g.Count() > 1)
                   .Select(g => g.Key)
                   .ToList();
        }
    }
}
