using ManageFileBE.Config;
using ManageFileBE.Models;
using ManageFileBE.Repository.Interface;

namespace ManageFileBE.Repository
{
    public class FileRepository : IFileRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public FileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool deleteFile(FileEntity fileEntity)
        {
            _dbContext.Remove(fileEntity);
            return _dbContext.SaveChanges() > 0;
        }

        public ICollection<FileEntity> getAllFile()
        {
            return _dbContext.FileEntity.OrderBy(f => f.UploadDate).ToList();
        }

        public FileEntity getFileById(int id)
        {
            return _dbContext.FileEntity.Where(p => p.Id == id).FirstOrDefault();
        }

        public bool saveFile(FileEntity fileEntity)
        {
            _dbContext.Add(fileEntity);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
