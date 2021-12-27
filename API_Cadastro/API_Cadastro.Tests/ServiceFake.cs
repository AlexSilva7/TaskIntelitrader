using API_Cadastro.Data;
using API_Cadastro.Models;
using API_Cadastro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Cadastro.Tests
{
    public class ServiceFake : IUserService
    {
        private BancoFake _db;

        public ServiceFake(BancoFake db)
        {
            _db = db;
        }

        public void Create(Usuario user)
        {
            _db.Users.Add(user);
        }

        public void Delete(Usuario user)
        {
            _db.Users.Remove(user);
        }

        public Usuario FindByID(string id)
        {
            Usuario obj = _db.Users.SingleOrDefault(p => p.ID.Equals(id));
            return obj;
        }

        public List<Usuario> GetAll()
        {
            if(_db.Users == null)
            {
                throw new NotImplementedException();
            }

            return _db.Users;
        }

        public void Update(Usuario user)
        {
            throw new NotImplementedException();
        }
    }
}
