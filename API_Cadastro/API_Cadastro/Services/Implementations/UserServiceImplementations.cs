using API_Cadastro.Data;
using API_Cadastro.Models;


namespace API_Cadastro.Services.Implementations
{
    public class UserServiceImplementations : IUserService
    {

        private UserDbContext _db;

        public UserServiceImplementations(UserDbContext db)
        {
            _db = db;
        }


        public Usuario FindByID(string id)
        {
            return _db.Users.Find(id);
        }

        public List<Usuario> GetAll()
        {
            return _db.Users.ToList();
        }

        public void Create(Usuario user)
        {
             _db.Add(user);
             _db.SaveChanges();
        }

        public void Delete(Usuario user)
        {

            //var userFromDb = _db.Users.Find(id);
            _db.Users.Remove(user);
            _db.SaveChanges();


        }

        public void Update(Usuario user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
        }
    }
}
