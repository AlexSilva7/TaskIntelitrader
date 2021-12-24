
using Xunit;
using API_Cadastro.Models;
using System.Collections.Generic;
using API_Cadastro.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace API_Cadastro.Tests
{
    public class ControllerTests
    {

        [Fact]
        public void TestaMetodoGet()
        {
            BancoFake database = new BancoFake();
            //List<Usuario> usuarios = new List<Usuario>();
            Usuario teste = new Usuario();

            teste.Name = "Arthur";
            teste.Surname = "Alentejo";
            teste.Age = 25;

            List<Usuario> lista = new List<Usuario> { teste };  

            //database.Users.Add(teste);
            database.Users = lista;

            ILogger<UserController> logger = new Logger<UserController>(new NullLoggerFactory());

            var controller = new UserController(database, logger);

            var obj = controller.Index();
            var obj2 = database;

            //Assert.Equal((IEnumerable<Usuario>)obj, (IEnumerable<Usuario>)obj2);


        }
    }
}
