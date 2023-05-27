using Microsoft.EntityFrameworkCore;

namespace Trabajeasy.Models
{
    public class trabajeasyContext : DbContext
    {
        public trabajeasyContext(DbContextOptions<trabajeasyContext> options) : base(options)
        {
        }
        public DbSet<publicacion> publicacions { get; set; }
    }
}
