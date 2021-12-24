using API_Cadastro.Controllers;
using API_Cadastro.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Cadastro.Tests
{
    public class ControllerFake : IUserController
    {
        public IActionResult Create(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Index()
        {
            throw new NotImplementedException();
        }

        public IActionResult Update(string id, Usuario obj)
        {
            throw new NotImplementedException();
        }

    }
}
