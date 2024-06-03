using System.ComponentModel.DataAnnotations;
namespace AdministracionCampeonatosQuimera.Models
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; }
        public int CelularCapitan { get; set; }
        public string? Nombre { get; set; } //Nombre del equipo
        public string? NombreCapitan { get; set; }

        //relaciones 1 ------> *
        //La relacion se debe a que un equipo puede tener muchos certificados 
        //de acuerdo a las diferentes disciplinas que va a inscribirse
        public virtual List<Certificado>? Certificados { get; set; }


    }
}
