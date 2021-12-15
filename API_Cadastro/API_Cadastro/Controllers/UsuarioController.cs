using API_Cadastro.Data;
using API_Cadastro.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Cadastro.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioDbContext _db;

        public UsuarioController(UsuarioDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Usuario> objUsuarioList = _db.Usuarios.ToList();
            return View(objUsuarioList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuario obj)
        {
            //Adicionando erro customizado
            //exemplo
            /*
             * if (obj.FirstName == obj.Surname)
                {
                ModelState.AddModelError("CustomError", "nome igual sobrenome");
                }
             * 
             */

            if (ModelState.IsValid)
            {
                _db.Usuarios.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(obj);
        }
    }
}
