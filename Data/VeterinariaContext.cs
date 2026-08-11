using ModeloDominio;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public  class VeterinariaContext : DbContext
    {
        public VeterinariaContext(DbContextOptions<VeterinariaContext> options) : base(options) { }
        public DbSet<Persona> Personas { get; set; } 
        public DbSet<Duenio> Duenios { get; set; } 
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
