using ManageFileBE.Dto;
using ManageFileBE.Models;
using ManageFileBE.Repository.Interface;
using ManageFileBE.Services.Interface;
using System.Security.Cryptography;

namespace ManageFileBE.Services.Impl
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
            Users user = _userRepos.GetById(id);
            if (user == null)
            {
                return _userRepos.Delete(user);
            }
            return true;
        }

        public Users FingByToken(string token)
        {
            return _userRepos.FindByToKen(token);
        }

        public IEnumerable<Users> GetAllUser()
        {
            return _userRepos.GetAll();
        }

        public Users GetUserById(long id)
        {
            return _userRepos.GetById(id);
        }

        public bool IsExists(string username)
        {
            return _userRepos.IsUserExists(username);
        }

        public bool SaveUser(Register account)
        {
             
            Users user = new Users()
            {
                Username = account.Username,
                Email = account.Email,
                FullName = account.FullName,
                CreatedDate = DateTime.Now,
                Role = account.Role,
                CurrentToken = ""
            };
            using (HMACSHA512? hmac = new HMACSHA512())
            {
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(account.Password));
            }
            return _userRepos.Save(user);
        }

        public bool UpdateUser(long id, Users user)
        {
            return _userRepos.Update(user);
        }   
        
    }
}
