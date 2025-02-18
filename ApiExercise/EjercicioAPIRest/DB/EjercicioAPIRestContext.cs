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

    }
}
