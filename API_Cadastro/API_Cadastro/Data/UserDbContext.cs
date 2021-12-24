
using API_Cadastro.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Cadastro.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Users { get; set; }

    }
}
