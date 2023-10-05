using ManageFileBE.Models;
using ManagerFileBE.Dto;

namespace ManageFileBE.Service.Interface
{
    public interface IFileService
    {
       
        public ICollection<FileEntity> getAllFile();
        public FileEntity getFileById(int id);
        public bool saveFile(String author, IFormFile file);
        public bool deleteFile(int id);
        public FileRespon viewFileById(int id);
    }
}
