using System.ComponentModel.DataAnnotations;

namespace AdministracionCampeonatosQuimera.Models
{
    public class Campeonato
    {
        [Key]
        public int Id { get; set; }
        public int CantEquipos { get; set; }
        public decimal CostoInscripcion { get; set; }
        public string? Disciplina { get; set; }
        public DateTime FechaRealizacion { get; set; }
        public string? Modalidad { get; set; }
        public string? Nombre { get; set; }

        //relaciones 1 ------> *
        public virtual List<Certificado>? Certificados { get; set; }
    }
}
