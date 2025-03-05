using EjercicioAPIRest.Models;
using Microsoft.EntityFrameworkCore;

namespace EjercicioAPIRest.DB
{
    public class EjercicioAPIRestContext:DbContext
    {
        public EjercicioAPIRestContext(DbContextOptions options)
            :base (options)
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<RefreshTokens> RefreshToken { get; set; }
    }
}
