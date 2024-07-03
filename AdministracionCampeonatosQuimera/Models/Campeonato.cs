using System.ComponentModel.DataAnnotations;

namespace AdministracionCampeonatosQuimera.Models
{
    public class Campeonato
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Integrantes ")]
        public int CantEquipos { get; set; }
        [Display(Name = "Inscripción ")]
        public decimal CostoInscripcion { get; set; }
        [Display(Name = "Disciplina ")]
        public string? Disciplina { get; set; }
        [Display(Name = "Fecha Realización ")]
        public DateTime FechaRealizacion { get; set; }
        [Display(Name = "Modalidad ")]
        public string? Modalidad { get; set; }
        [Display(Name = "Campeonato ")]
        public string? Nombre { get; set; }

        //relaciones 1 ------> *
        public virtual List<Certificado>? Certificados { get; set; }
    }
}
