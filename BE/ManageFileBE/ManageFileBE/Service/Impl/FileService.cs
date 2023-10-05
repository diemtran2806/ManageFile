using ManageFileBE.Config;
using ManageFileBE.Dto;
using ManageFileBE.Exceptions;
using ManageFileBE.Models;
using ManageFileBE.Repository.Interface;
using ManageFileBE.Service.Interface;

namespace ManageFileBE.Service
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IFileStore _fileStore;
        public FileService(IFileRepository _fileRepository, IFileStore fileStore)
        {
            this._fileRepository = _fileRepository;
            this._fileStore = fileStore;
        }
        public bool deleteFileById(int id)
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

        public FileEntity getFileById(int id)
        {
            FileEntity fileEntity = this._fileRepository.getFileById(id);
            if (fileEntity != null)
                return fileEntity;
            else throw new NotFoundException("Không tìm thấy file");
        }
        public bool saveFile(string author, IFormFile file)
        {
            if (_fileStore.saveFile(file) == true)
            {
                FileEntity fileEntity = new FileEntity();
                fileEntity.FileName = file.FileName;
                fileEntity.Author = author;
                fileEntity.UploadDate = DateTime.Now;
                return this._fileRepository.saveFile(fileEntity);
            }
            return false;
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

        public ICollection<FileEntity> getAllFile()
        {
            ICollection<FileEntity> files = this._fileRepository.getAllFile();
            if (files.Count() > 0)
                return files;
            else throw new NotFoundException("Danh sách rỗng");
        }

        public FileRespon viewFileById(int id)
        {
            FileEntity fileEntity = this._fileRepository.getFileById(id);
            {
                String contentType = this.getContentType(fileEntity.FileName);

                byte[] fileBytes = this._fileStore.readFileByName(fileEntity.FileName);

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
    }
}
