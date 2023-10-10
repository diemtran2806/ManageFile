using ManageFileBE.Models;

namespace ManageFileBE.Repository.Interface
{
    public interface IUserRepository
    {
        public IEnumerable<Users> GetAll();
        public Users GetById(long id);
        public bool IsUserExists(string username);
        public bool Save(Users user);
        public bool Update(Users user);
        public bool Delete(Users user);
        public Users FindByToKen(string token);
    }
}
