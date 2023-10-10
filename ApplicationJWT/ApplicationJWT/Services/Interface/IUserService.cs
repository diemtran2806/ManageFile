using ApplicationJWT.DTOs;
using ApplicationJWT.Models;

namespace ApplicationJWT.Services.Interface
{
    public interface IUserService
    {
        public IEnumerable<User> GetAllUser();
        public User FingByToken(string token);
        public User GetUserById(long id);
        public bool IsExists(string username);
        public bool SaveUser(Register account);
        public bool UpdateUser(long id, User user);
        public bool DeleteUserById(long id);

    }
}
