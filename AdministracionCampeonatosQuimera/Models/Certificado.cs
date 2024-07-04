using System.ComponentModel.DataAnnotations;

namespace AdministracionCampeonatosQuimera.Models
{
    public class Certificado
    {
        [Key]
        public int Id { get; set; }

        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        //relaciones de * ----> 1
        public int UsuarioId { get; set; }
        public int CampeonatoId { get; set; }
        public int EquipoId { get; set; }

        public virtual Usuario? Usuario { get; set; }
        public virtual Campeonato? Campeonato { get; set; }
        public virtual Equipo? Equipo { get; set; }
    }
}
