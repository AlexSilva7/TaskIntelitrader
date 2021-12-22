using API_Cadastro.Data;
using API_Cadastro.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Cadastro.Controllers
{
    public interface IController
    {
        public IActionResult Index();
        public IActionResult Create([FromBody] Usuario obj);
        public IActionResult Update(string id, [FromBody] Usuario obj);
        public IActionResult Delete(string id);
    }
}
