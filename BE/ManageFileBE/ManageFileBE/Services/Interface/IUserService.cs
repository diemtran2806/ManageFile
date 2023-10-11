using ManageFileBE.Dto;
using ManageFileBE.Models;

namespace ManageFileBE.Services.Interface
{
    public interface IUserService
    {
        public IEnumerable<Users> GetAllUser();
        public Users FingByToken(string token);
        public Users GetUserById(long id);
        public bool IsExists(string username);
        public bool SaveUser(Register account);
        public bool UpdateUser(long id, Users user);
        public bool DeleteUserById(long id);

    }
}
