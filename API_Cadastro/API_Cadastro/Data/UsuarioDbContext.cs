
using API_Cadastro.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Cadastro.Data
{
    public class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
