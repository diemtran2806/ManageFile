using ApplicationJWT.Models;

namespace ApplicationJWT.Repository.Interface
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAll();
        public User GetById(long id);
        public bool IsUserExists(string username);
        public bool Save(User user);
        public bool Update(User user);
        public bool Delete(User user);
        User FindByToKen(string token);
    }
}
