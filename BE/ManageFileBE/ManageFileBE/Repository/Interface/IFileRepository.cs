using ManageFileBE.Models;

namespace ManageFileBE.Repository.Interface
{
    public interface IFileRepository
    {
        public ICollection<FileEntity> getAllFile();
        public FileEntity getFileById(int id);
        public bool updateFile(FileEntity fileEntity);
        public bool saveFile(FileEntity fileEntity);
        public bool deleteFile(FileEntity fileEntity);
    }
}
