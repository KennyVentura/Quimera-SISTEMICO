using Microsoft.EntityFrameworkCore;
using AdministracionCampeonatosQuimera.Models;
namespace AdministracionCampeonatosQuimera.Contexto
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions options): base(options) 
        { 
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Campeonato> Campeonatos { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Certificado> Certificados { get; set; }
    }
}
