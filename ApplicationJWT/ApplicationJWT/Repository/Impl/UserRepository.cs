using ApplicationJWT.Models;
using ApplicationJWT.Repository.Interface;

namespace ApplicationJWT.Repository.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dbContext;
        public UserRepository(DataContext dataContext)
        {
            _dbContext = dataContext;
        }
        public bool Delete(User user)
        {
            _dbContext.User.Remove(user);
            return _dbContext.SaveChanges() > 0;
        }

        public User FindByToKen(string token)
        {
            return _dbContext.User.FirstOrDefault(u => u.Token == token);
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.User.ToList();
        }

        public User GetById(long id)
        {
            return _dbContext.User.Find(id);
        }

        public bool IsUserExists(string username)
        {
            return _dbContext.User.Any(u => u.Username == username);
        }

        public bool Save(User user)
        {
            _dbContext.User.Add(user);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Update(User user)
        {
            _dbContext.User.Update(user);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
