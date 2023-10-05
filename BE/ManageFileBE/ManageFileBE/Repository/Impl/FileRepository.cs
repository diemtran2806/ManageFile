
using ManageFileBE.Config;
using ManageFileBE.Models;
using ManageFileBE.Repository.Interface;

namespace ManageFileBE.Repository.Impl
{
    public class FileRepository : IFileRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public FileRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public bool deleteFile(FileEntity fileEntity)
        {
            this._dbContext.Remove(fileEntity);
            return this._dbContext.SaveChanges() > 0;
        }

        public ICollection<FileEntity> getAllFile()
        {
            return this._dbContext.FileEntity.ToList();
        }

        public FileEntity getFileById(int id)
        {
           return this._dbContext.FileEntity.Where(f => f.Id == id).FirstOrDefault();
        }

        public bool saveFile(FileEntity fileEntity)
        {
            this._dbContext.Add(fileEntity);
            return this._dbContext.SaveChanges() > 0;
        }
    }
}
