using API_Cadastro.Data;
using API_Cadastro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Cadastro.Tests
{
    public class BancoFake : IUserDbContext
    {
        public List<Usuario> Users { get; set; }
        DbSet<Usuario> IUserDbContext.Users { get ; set ; }

    }
}
