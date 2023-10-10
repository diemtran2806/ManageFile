using ManageFileBE.Config;
using ManageFileBE.Models;
using ManageFileBE.Repository.Interface;

namespace ManageFileBE.Repository.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dataContext)
        {
            _dbContext = dataContext;
        }
        public bool Delete(Users user)
        {
            _dbContext.Users.Remove(user);
            return _dbContext.SaveChanges() > 0;
        }

        public Users FindByToKen(string token)
        {
            return _dbContext.Users.FirstOrDefault(u => u.CurrentToken == token);
        }

        public IEnumerable<Users>? GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public Users GetById(long id)
        {
            return _dbContext.Users.Find(id);


        }

        public bool IsUserExists(string username)
        {
            return _dbContext.Users.Any(u => u.Username == username);
        }

        public bool Save(Users user)
        {
            _dbContext.Users.Add(user);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Update(Users user)
        {
            _dbContext.Users.Update(user);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
