using ApplicationJWT.DTOs;
using ApplicationJWT.Models;
using ApplicationJWT.Repository.Interface;
using ApplicationJWT.Services.Interface;
using System.Security.Cryptography;

namespace ApplicationJWT.Services.Impl
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepos;
        public UserService(IUserRepository userRepos)
        {
            this._userRepos = userRepos;
        }
        public bool DeleteUserById(long id)
        {
            User user = _userRepos.GetById(id);
            if (user == null)
            {
                return _userRepos.Delete(user);
            }
            return true;
        }

        public User FingByToken(string token)
        {
            return _userRepos.FindByToKen(token);
        }

        public IEnumerable<User> GetAllUser()
        {
            return _userRepos.GetAll();
        }

        public User GetUserById(long id)
        {
            return _userRepos.GetById(id);
        }

        public bool IsExists(string username)
        {
            return _userRepos.IsUserExists(username);
        }

        public bool SaveUser(Register account)
        {
             
            User user = new User()
            {
                Username = account.Username,
                Email = account.Username,
                Password = account.Password,
                CreatedDate = DateTime.Now,
                Role = account.Role,
                Token = ""
            };
            using (HMACSHA512? hmac = new HMACSHA512())
            {
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(account.Password));
            }
            return _userRepos.Save(user);
        }

        public bool UpdateUser(long id, User user)
        {
            throw new NotImplementedException();
        }
        
    }
}
