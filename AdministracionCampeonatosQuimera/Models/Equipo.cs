using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdministracionCampeonatosQuimera.Models
{
    public class Equipo
    {
        
        [Key]
        public int Id { get; set; }
        [Display(Name = "Celular de Capitan ")]
        public int CelularCapitan { get; set; }
        [Display(Name = "Nombre de Equipo ")]
        public string? Nombre { get; set; } //Nombre del equipo
        [Display(Name = "Nombre de Capitan ")]
        public string? NombreCapitan { get; set; }
       
        //relaciones 1 ------> *
        //La relacion se debe a que un equipo puede tener muchos certificados 
        //de acuerdo a las diferentes disciplinas que va a inscribirse
        public virtual List<Certificado>? Certificados { get; set; }


    }
}
