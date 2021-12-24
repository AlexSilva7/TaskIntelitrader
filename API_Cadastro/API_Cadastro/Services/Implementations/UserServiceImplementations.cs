using API_Cadastro.Data;
using API_Cadastro.Models;

/*
namespace API_Cadastro.Services.Implementations
{
    public class UserServiceImplementations : IUserService
    {

        private UserDbContext _db;

        public UserServiceImplementations(UserDbContext db)
        {
            _db = db;
        }

        public List<Usuario> GetAll()
        {
            return _db.Users.ToList();
        }

        public Usuario Create(Usuario user)
        {
            try
            {
                _db.Add(user);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }

        public void Delete(string id)
        {
            try
            {
                var userFromDb = _db.Users.Find(id);

                if (userFromDb == null)
                {
                    
                }

            }
            
         
        }

        public Usuario Update(Usuario user)
        {
            throw new NotImplementedException();
        }
    }
}
*/