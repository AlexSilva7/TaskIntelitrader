
using API_Cadastro.Models;

namespace API_Cadastro.Services
{
    public interface IUserService
    {
        Usuario FindByID(string id);
        List<Usuario> GetAll();
        void Create(Usuario user);
        void Update(Usuario user);
        void Delete(Usuario user);
    }
}
