using API_Cadastro.Data;
using API_Cadastro.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Cadastro.Controllers
{
    public class UserController : Controller
    {
        /*
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }
        */

        private readonly UserDbContext _db;

        public UserController(UserDbContext db)
        {
            _db = db;
        }

        [HttpGet("Users/")]
        public IActionResult Index()
        {
            IEnumerable<Usuario> objUsuarioList = _db.Users.ToList();

            return Ok(objUsuarioList);
        }


        [HttpPost("Users/")]
        public IActionResult Create([FromBody] Usuario obj)
        {

            if (obj == null)
            {
                return BadRequest("Objeto invalido!");
            }

            if(obj.FirstName == null || obj.FirstName == "")
            {
                return BadRequest("Objeto invalido!");
            }

            if (obj.Age <= 0)
            {
                return BadRequest("Objeto invalido!");
            }
            
            _db.Users.Add(obj);
            _db.SaveChanges();
            return Ok("Usuario adicionado com sucesso!");

        }


        [HttpPut("Users/{id}")]
        public IActionResult Update(string id, [FromBody] Usuario obj)
        {

            if (id == null || id == "")
            {
                return BadRequest("Objeto invalido!");
            }

            if (obj.FirstName == null || obj.FirstName == "")
            {
                return BadRequest("Objeto invalido!");
            }

            if (obj.Age <= 0)
            {
                return BadRequest("Objeto invalido!");
            }

            if (obj == null)
            {
                return BadRequest("Objeto invalido!");
            }

            var userFromDb = _db.Users.Find(id);
            
            userFromDb.FirstName = obj.FirstName;
            userFromDb.Surname = obj.Surname;
            userFromDb.Age = obj.Age;
            
            _db.Users.Update(userFromDb);
            _db.SaveChanges();
            return Ok("Usuario atualizado com sucesso!");

        }
        

        [HttpDelete("Users/{id}")]
        public IActionResult Delete(string id)
        {
            if (id == null || id == "")
            {
                //return NotFound();
                return BadRequest("Objeto invalido!");
            }

            var userFromDb = _db.Users.Find(id);

            if (userFromDb == null)
            {
                //return NotFound();
                return BadRequest("Erro: Usuario nao encontrado!");
            }

            _db.Users.Remove(userFromDb);
            _db.SaveChanges();

            //mostrar alteracao
            return Ok("Usuario deletado com sucesso!");
        }

    }
}
