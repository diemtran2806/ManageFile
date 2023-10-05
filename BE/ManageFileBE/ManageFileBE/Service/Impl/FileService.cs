using FileManager.Dto;
using ManageFileBE.Exceptions;
using ManageFileBE.Models;
using ManageFileBE.Repository.Interface;
using ManageFileBE.Service.Interface;

namespace ManageFileBE.Service
{
    public class FileService : IFileService
    {
        private IFileRepository _fileRepository;
        private IFileStore _fileStore;
        public FileService(IFileRepository fileRepository, IFileStore fileStore)
        {
            this._fileRepository = fileRepository;
            this._fileStore = fileStore;
        }
        public bool deleteFile(int id)
        {
            FileEntity fileEntity = this._fileRepository.getFileById(id);

            if (fileEntity != null)
            {
                bool check =  this._fileRepository.deleteFile(fileEntity);
                if (check)
                {
                    this._fileStore.deleteFile(fileEntity.FileName);
                    return true;
                }
            }
            throw new NotFoundException("Không tìm thấy file chỉ định");
        }

        public ICollection<FileEntity> getAllFile()
        {
            ICollection<FileEntity> files = this._fileRepository.getAllFile();
            if (files.Count() > 0)
                return files;
            else throw new NotFoundException("Danh sách rỗng");
        }

        public FileEntity getFileById(int id)
        {
            FileEntity files = this._fileRepository.getFileById(id);
            if (files != null)
                return files;
            else throw new NotFoundException("Không tìm thấy file");
        }

        public bool saveFile(string author, IFormFile file)
        {

            if (_fileStore.storeFile(file) == true)
            {
                FileEntity fileEntity = new FileEntity();
                fileEntity.FileName = file.FileName;
                fileEntity.Author = author;
                fileEntity.UploadDate = DateTime.Now;
               
                return this._fileRepository.saveFile(fileEntity);
            }
            return false;
        }

        public FileRespon viewFileById(int id)
        {
            FileEntity fileEntity = this._fileRepository.getFileById(id);
            if (fileEntity != null)
            {
                String contentType = this.getContentType(fileEntity.FileName);

                byte[] fileBytes = this._fileStore.viewFileByteCode(fileEntity.FileName);

                if (fileBytes != null && fileBytes.Length > 0)
                {
                    FileRespon fileRespon = new FileRespon();
                    fileRespon.FileBytes = fileBytes;
                    fileRespon.ContentType = contentType;
                    return fileRespon;
                }
            }
            throw new NotFoundException("Không tim thấy file");
        }
        public String getContentType(String fileName)
        {
            fileName = fileName.Trim().ToLower();

            if (fileName.EndsWith(".jpg") || fileName.EndsWith(".jpeg"))
            {
                return "image/jpeg";
            }
            else if (fileName.EndsWith(".png"))
            {
                return "image/png";
            }
            else if (fileName.EndsWith(".gif"))
            {
                return "image/gif";
            }
            else if (fileName.EndsWith(".pdf"))
            {
                return "application/pdf";
            }
            else if (fileName.EndsWith(".doc") || fileName.EndsWith(".docx"))
            {
                return "application/msword";
            }
            else if (fileName.EndsWith(".xls") || fileName.EndsWith(".xlsx"))
            {
                return "application/vnd.ms-excel";
            }
            else
                return "application/octet-stream";
        }
    }
}
