using Microsoft.EntityFrameworkCore;

namespace ComisionesJP.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Estas son las tablas que va a leer de tu base ComisionesDB
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<CalculadorComision> CalculadorComision { get; set; }
        public DbSet<Venta> Venta { get; set; }
    }
}