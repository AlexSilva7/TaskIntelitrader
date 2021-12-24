using API_Cadastro.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Cadastro.Data
{
    public interface IUserDbContext
    {
        public DbSet<Usuario> Users { get; set; }

    }
}
