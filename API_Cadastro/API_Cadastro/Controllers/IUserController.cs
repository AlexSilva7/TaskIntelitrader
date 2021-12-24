using API_Cadastro.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Cadastro.Controllers
{
    public interface IUserController
    {
        public IActionResult Index();
        public IActionResult Create(Usuario obj);
        public IActionResult Update(string id, Usuario obj);
        public IActionResult Delete(string id);

    }

}
