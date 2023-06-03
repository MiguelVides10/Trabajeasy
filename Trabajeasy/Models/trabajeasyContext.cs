using Microsoft.EntityFrameworkCore;

namespace Trabajeasy.Models
{
    public class trabajeasyContext : DbContext
    {
        public trabajeasyContext(DbContextOptions<trabajeasyContext> options) : base(options)
        {
        }
        public DbSet<publicacion> publicacion { get; set; }
        public DbSet<tipoTrabajo> tipoTrabajo { get; set; }
        public DbSet<empresa> empresa { get; set; }
        public DbSet<empleador> empleador { get; set; }
        public DbSet<departamentos> departamentos { get; set;}
        public DbSet<usuario> usuario { get; set; }
        public DbSet<recurso> recurso { get; set; }
    }
}
