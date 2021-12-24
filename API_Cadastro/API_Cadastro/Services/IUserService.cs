
using API_Cadastro.Models;

namespace API_Cadastro.Services
{
    public interface IUserService
    {
        Usuario Create(Usuario user);
        List<Usuario> GetAll();
        Usuario Update(Usuario user);
        void Delete(string id);
    }
}
