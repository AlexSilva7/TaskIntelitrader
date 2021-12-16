
/*
using API_Cadastro.Data;
using API_Cadastro.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Cadastro.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UserDbContext _db;

        public UsuarioController(UserDbContext db)
        {
            _db = db;
        }

        
        public IActionResult Index()
        {
            IEnumerable<Usuario> objUsuarioList = _db.Users.ToList();

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
            //
             // if (obj.FirstName == obj.Surname)
              //  {
                //    ModelState.AddModelError("CustomError", "nome igual sobrenome");
                //}


            if (ModelState.IsValid)
            {
                _db.Users.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(obj);
        }
        


        //GET
        public IActionResult Edit(string? id)
        {
            if(id==null || id == "")
            {
                return NotFound();
            }

            var UsuarioFromDb = _db.Users.Find(id);
            //var UsuarioFromDbFirst = _db.Usuarios.FirstOrDefault(u => u.ID == id);
            //var UsuarioFromDbSingle = _db.Usuarios.SingleOrDefault(u => u.ID == id);
            
            if (UsuarioFromDb == null)
            {
                return NotFound();
            }
            
            return View(UsuarioFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Usuario obj)
        {
            //Adicionando erro customizado
            //exemplo
            

            if (ModelState.IsValid)
            {
                _db.Users.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }



        //GET
        public IActionResult Delete(string? id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }

            var UsuarioFromDb = _db.Users.Find(id);
            //var UsuarioFromDbFirst = _db.Usuarios.FirstOrDefault(u => u.ID == id);
            //var UsuarioFromDbSingle = _db.Usuarios.SingleOrDefault(u => u.ID == id);

            if (UsuarioFromDb == null)
            {
                return NotFound();
            }

            return View(UsuarioFromDb);
        }

        //dando nome diferente
        //[HttpPost, ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(string? id)
        {
            var obj = _db.Users.Find(id);

            if(obj == null)
            {
                return NotFound();
            }

            
            _db.Users.Remove(obj);
            _db.SaveChanges();
            //mostrar alteracao
            TempData["success"] = "Usuario deletado com sucesso";
            return RedirectToAction("Index");

        }
        
    }
}
*/
