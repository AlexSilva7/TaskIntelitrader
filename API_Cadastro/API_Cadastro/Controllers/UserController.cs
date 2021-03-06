using API_Cadastro.Data;
using API_Cadastro.Models;
using API_Cadastro.Logging;
using Microsoft.AspNetCore.Mvc;
using API_Cadastro.Services;

namespace API_Cadastro.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        //private readonly IUserDbContext _db;
        private readonly IUserService _userService;

        public UserController(IUserService userService, ILogger<UserController> log)
        {
            _logger = log;
            _userService = userService;
            //_db =  db;
        }

        [HttpGet("Users/")]
        public IActionResult Index()
        {

            _logger.LogInformation("Executando /Users -> GET");

            try
            {
                IEnumerable<Usuario> objUsuarioList = _userService.GetAll();

                _logger.LogInformation(Ok().StatusCode.ToString() + 
                    " Resposta bem sucedida /Users -> GET");

                return Ok(objUsuarioList);
            }
            catch (Exception)
            {
                _logger.LogInformation(Problem().StatusCode.ToString() + 
                    " Erro do servidor /Users -> GET");

                return Problem("Erro do servidor!");
            }
        }
        


        [HttpPost("Users/")]
        public IActionResult Create([FromBody] Usuario obj)
        {
            _logger.LogInformation(" Executando /Users -> POST");

            if (obj == null)
            {
                _logger.LogInformation(BadRequest().StatusCode.ToString() + 
                    " Requisição mal sucedida(Cliente) /Users -> POST");

                return BadRequest("Objeto invalido!");
            }

            if(obj.Name == null || obj.Name == "")
            {
                _logger.LogInformation(BadRequest().StatusCode.ToString() + 
                    " Requisição mal sucedida(Cliente) /Users -> POST");

                return BadRequest("Objeto invalido!");
            }

            if (obj.Age < 0)
            {
                _logger.LogInformation(BadRequest().StatusCode.ToString() + 
                    " Requisição mal sucedida(Cliente) /Users -> POST");

                return BadRequest("Objeto invalido!");
            }

            try
            {
                _userService.Create(obj);

                _logger.LogInformation(Ok().StatusCode.ToString() + 
                    " Resposta bem sucedida /Users -> POST");

                return Ok("Usuario adicionado com sucesso!");
            }
            catch (Exception)
            {
                _logger.LogInformation(Problem().StatusCode.ToString() + 
                    " Erro do servidor /Users -> POST");

                return Problem("Erro do servidor!");
            }

        }


        [HttpPut("Users/{id}")]
        public IActionResult Update(string id, [FromBody] Usuario obj)
        {
            _logger.LogInformation($"Executando /Users/{id} -> PUT");

            if (id == null || id == "")
            {
                _logger.LogInformation(BadRequest().StatusCode.ToString() + 
                    $" Requisição mal sucedida(Cliente) /Users/{id} -> PUT");
            
                return BadRequest("Objeto invalido!");
            }

            if (obj.Name == null || obj.Name == "")
            {
                _logger.LogInformation(BadRequest().StatusCode.ToString() + 
                    $" Requisição mal sucedida(Cliente) /Users/{id} -> PUT");

                return BadRequest("Objeto invalido!");
            }

            if (obj.Age <= 0)
            {
                _logger.LogInformation(BadRequest().StatusCode.ToString() + 
                    $" Requisição mal sucedida(Cliente) /Users/{id} -> PUT");

                return BadRequest("Objeto invalido!");
            }

            if (obj == null)
            {
                _logger.LogInformation(BadRequest().StatusCode.ToString() + 
                    $" Requisição mal sucedida(Cliente) /Users/{id} -> PUT");

                return BadRequest("Objeto invalido!");
            }

            try
            {

                var userFromDb = _userService.FindByID(id);

                if (userFromDb == null)
                {
                    _logger.LogInformation(BadRequest().StatusCode.ToString() +
                        $" Requisição mal sucedida(Cliente) /Users/{id} -> PUT");
                    return BadRequest("Usuario nao encontrado!");
                }

                userFromDb.Name = obj.Name;
                userFromDb.Surname = obj.Surname;
                userFromDb.Age = obj.Age;

                _userService.Update(userFromDb);

                _logger.LogInformation(Ok().StatusCode.ToString() + 
                    $" Resposta bem sucedida /Users/{id} -> PUT");

                return Ok("Usuario atualizado com sucesso!");
            }
            catch (Exception)
            {
                _logger.LogInformation(Problem().StatusCode.ToString() + 
                    $" Erro do servidor /Users/{id} -> PUT");

                return Problem("Erro do servidor!");
            }

        }
        

        [HttpDelete("Users/{id}")]
        public IActionResult Delete(string id)
        {
            _logger.LogInformation($" Executando /Users/{id} -> DELETE");

            if (id == null || id == "")
            {
                _logger.LogInformation(BadRequest().StatusCode.ToString() + 
                    $" Requisição mal sucedida(Cliente) /Users/{id} -> DELETE");

                return BadRequest("Objeto invalido!");
            }

            try
            {

                var userFromDb = _userService.FindByID(id);

                if (userFromDb == null)
                {
                    _logger.LogInformation(BadRequest().StatusCode.ToString() + 
                        $" Requisição mal sucedida(Cliente) /Users/{id} -> DELETE");

                    return BadRequest("Usuario nao encontrado!");
                }

                _userService.Delete(userFromDb);

                _logger.LogInformation(Ok().StatusCode.ToString() + 
                    $" Resposta bem sucedida /Users/{id} -> DELETE");

                return Ok("Usuario deletado com sucesso!");

            }
            catch (Exception)
            {
                _logger.LogInformation(Problem().StatusCode.ToString() + 
                    $" Erro do servidor /Users/{id} -> DELETE");

                return Problem("Erro do servidor!");
            }
        }
    }
}
