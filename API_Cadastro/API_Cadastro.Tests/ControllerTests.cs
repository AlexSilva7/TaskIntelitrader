
using Xunit;
using API_Cadastro.Models;
using System.Collections.Generic;
using API_Cadastro.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API_Cadastro.Tests
{
    public class ControllerTests
    {

        [Fact]
        public void TestaMetodoGet()
        {
            BancoFake database = new BancoFake();
            List<Usuario> teste = new List<Usuario>();

            teste.Add(new Usuario
            {
                Name = "Arthur",
                Surname = "Alentejo",
                Age = 25
            });

            database.Users = teste;
            ServiceFake service = new ServiceFake(database);
            ILogger<UserController> logger = new Logger<UserController>(new NullLoggerFactory());

            var controller = new UserController(service, logger);
 
            Assert.IsType<OkObjectResult>(controller.Index());

        }

        [Fact]
        public void TestaMetodoPost_OkCompleto()
        {
            BancoFake database = new BancoFake();
            List<Usuario> teste = new List<Usuario>();

            database.Users = teste;
            ServiceFake service = new ServiceFake(database);
            ILogger<UserController> logger = new Logger<UserController>(new NullLoggerFactory());

            var controller = new UserController(service, logger);

            Assert.IsType<OkObjectResult>(controller.Create(new Usuario
            {
                Name = "Arthur",
                Surname = "Alentejo",
                Age = 25
            }));

        }

        [Fact]
        public void TestaMetodoPost_OkSemSobrenome()
        {
            BancoFake database = new BancoFake();
            List<Usuario> teste = new List<Usuario>();

            database.Users = teste;
            ServiceFake service = new ServiceFake(database);
            ILogger<UserController> logger = new Logger<UserController>(new NullLoggerFactory());

            var controller = new UserController(service, logger);

            Assert.IsType<OkObjectResult>(controller.Create(new Usuario
            {
                Name = "Arthur",
                Age = 25
            }));

        }

        [Fact]
        public void TestaMetodoPost_BadRequest_SemIdade()
        {
            BancoFake database = new BancoFake();
            List<Usuario> teste = new List<Usuario>();

            database.Users = teste;
            ServiceFake service = new ServiceFake(database);
            ILogger<UserController> logger = new Logger<UserController>(new NullLoggerFactory());

            var controller = new UserController(service, logger);

            Assert.IsType<BadRequestObjectResult>(controller.Create(new Usuario
            {
                Name = "Arthur",
                Surname = "Alentejo"
            }));

        }

        [Fact]
        public void TestaMetodoPost_BadRequest_SemName()
        {
            BancoFake database = new BancoFake();
            List<Usuario> teste = new List<Usuario>();

            database.Users = teste;
            ServiceFake service = new ServiceFake(database);
            ILogger<UserController> logger = new Logger<UserController>(new NullLoggerFactory());

            var controller = new UserController(service, logger);

            Assert.IsType<BadRequestObjectResult>(controller.Create(new Usuario
            {
                Surname = "Alentejo",
                Age = 30
            }));

        }


        [Fact]
        public void TestaMetodoPut_AlteraIdade()
        {
            BancoFake database = new BancoFake();
            List<Usuario> teste = new List<Usuario>();

            teste.Add(new Usuario{
                ID = "XXXX",
                Name = "Alex",
                Surname = "Silva",
                Age = 30
            });


            database.Users = teste;
            ServiceFake service = new ServiceFake(database);
            ILogger<UserController> logger = new Logger<UserController>(new NullLoggerFactory());

            var controller = new UserController(service, logger);

            controller.Update("XXXX", new Usuario
            {
                Name = "Alex",
                Surname = "Silva",
                Age = 28
            });

            Usuario ?obj = database.Users.SingleOrDefault(p => p.ID.Equals("XXXX"));

            Assert.Equal(28, obj.Age);
            
        }

        [Fact]
        public void TestaMetodoPut_AlteraNome()
        {
            BancoFake database = new BancoFake();
            List<Usuario> teste = new List<Usuario>();

            teste.Add(new Usuario
            {
                ID = "XXXX",
                Name = "Alex",
                Surname = "Silva",
                Age = 30
            });


            database.Users = teste;
            ServiceFake service = new ServiceFake(database);
            ILogger<UserController> logger = new Logger<UserController>(new NullLoggerFactory());

            var controller = new UserController(service, logger);

            controller.Update("XXXX", new Usuario
            {
                Name = "Roberto",
                Surname = "Silva",
                Age = 28
            });

            Usuario ?obj = database.Users.SingleOrDefault(p => p.ID.Equals("XXXX"));

            Assert.Equal("Roberto", obj.Name);

        }

        [Fact]
        public void TestaMetodoPut_EnviaObjetoInvalidoSemIdade_NaoAltera()
        {
            BancoFake database = new BancoFake();
            List<Usuario> teste = new List<Usuario>();

            teste.Add(new Usuario
            {
                ID = "XXXX",
                Name = "Alex",
                Surname = "Silva",
                Age = 30
            });


            database.Users = teste;
            ServiceFake service = new ServiceFake(database);
            ILogger<UserController> logger = new Logger<UserController>(new NullLoggerFactory());

            var controller = new UserController(service, logger);

            Assert.IsType<BadRequestObjectResult> (controller.Update("XXXX", new Usuario
            {
                Name = "Tiago",
                Surname = "Silva"
            }));

            Usuario? obj = database.Users.SingleOrDefault(p => p.ID.Equals("XXXX"));

            Assert.Equal("Alex", obj.Name);

        }

        [Fact]
        public void TestaMetodoPut_IDInexistente()
        {
            BancoFake database = new BancoFake();
            List<Usuario> teste = new List<Usuario>();

            teste.Add(new Usuario
            {
                ID = "XXXX",
                Name = "Alex",
                Surname = "Silva",
                Age = 30
            });

            teste.Add(new Usuario
            {
                ID = "YYYY",
                Name = "Joao",
                Surname = "Silva",
                Age = 30
            });


            database.Users = teste;
            ServiceFake service = new ServiceFake(database);
            ILogger<UserController> logger = new Logger<UserController>(new NullLoggerFactory());

            var controller = new UserController(service, logger);

            Assert.IsType<BadRequestObjectResult>(controller.Update("ZZZZ", new Usuario
            {
                Name = "Tiago",
                Surname = "Silva",
                Age = 30
            }));

        }

        [Fact]
        public void TestaMetodoDelete_Ok()
        {
            BancoFake database = new BancoFake();
            List<Usuario> teste = new List<Usuario>();

            teste.Add(new Usuario
            {
                ID = "XXXX",
                Name = "Alex",
                Surname = "Silva",
                Age = 30
            });

            teste.Add(new Usuario
            {
                ID = "YYYY",
                Name = "Joao",
                Surname = "Silva",
                Age = 30
            });


            database.Users = teste;
            ServiceFake service = new ServiceFake(database);
            ILogger<UserController> logger = new Logger<UserController>(new NullLoggerFactory());

            var controller = new UserController(service, logger);

            Assert.IsType<OkObjectResult>(controller.Delete("XXXX"));

            Assert.Equal(1, teste.Count);

        }

        [Fact]
        public void TestaMetodoDelete_BadRequest_IDInexistente()
        {
            BancoFake database = new BancoFake();
            List<Usuario> teste = new List<Usuario>();

            teste.Add(new Usuario
            {
                ID = "XXXX",
                Name = "Alex",
                Surname = "Silva",
                Age = 30
            });

            teste.Add(new Usuario
            {
                ID = "YYYY",
                Name = "Joao",
                Surname = "Silva",
                Age = 30
            });


            database.Users = teste;
            ServiceFake service = new ServiceFake(database);
            ILogger<UserController> logger = new Logger<UserController>(new NullLoggerFactory());

            var controller = new UserController(service, logger);

            Assert.IsType<BadRequestObjectResult>(controller.Delete("AAAA"));

            Assert.Equal(2, teste.Count);

        }
    }
}
