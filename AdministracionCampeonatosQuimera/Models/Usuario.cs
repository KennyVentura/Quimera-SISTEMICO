using AdministracionCampeonatosQuimera.Dto;
using System.ComponentModel.DataAnnotations;

namespace AdministracionCampeonatosQuimera.Models
{
    public class Usuario
    {
        //todas las clases tendran un key de autenticacion, es decir un "Id"
        [Key] //Annotation
        public int Id { get; set; }

        //generalmente un string va con ? para que la variable pueda tener valor o no 
        [Required, MinLength(5)]
        public string? Email { get; set; }
        [Required, MinLength(5)]
        public string? Nombre { get; set; }
        [Required, MinLength(3)]
        public string? Password { get; set; }
        public RolEnum Rol { get; set; }

        //relaciones 1 ------> *
        public virtual List<Certificado>? Certificados { get; set; }

    }
}
