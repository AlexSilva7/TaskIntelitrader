using API_Cadastro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;


namespace API_Cadastro.Data
{
    //public interface IUserDbContext : IInfrastructure<IServiceProvider>, IResettableService, IDisposable, IAsyncDisposable

    public interface IUserDbContext
    {
        DbSet<Usuario> Users { get; set; }

    }

}

