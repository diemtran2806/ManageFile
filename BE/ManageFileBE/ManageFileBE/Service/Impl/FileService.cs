
﻿using ManageFileBE.Exceptions;
using ManageFileBE.Models;
using ManageFileBE.Repository.Interface;
using ManageFileBE.Service.Interface;
using ManageFileBE.Dto;

namespace ManageFileBE.Service.Impl
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

        public ICollection<FileEntity> getAllFile()
        {
            ICollection < FileEntity > fileEntities =  this._fileRepository.getAllFile();
            if (fileEntities.Count > 0)
                return fileEntities;
            else
                throw new NotFoundException("Danh sách rỗng");
        }

        public FileEntity getFileById(int id)
        {
            FileEntity fileEntity = this._fileRepository.getFileById(id);
            if (fileEntity != null)
                return fileEntity;
            else throw new NotFoundException("Không tìm thấy file");
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
       

        public async Task<Boolean> saveFileAsync(string author, IFormFile file)
        {
            String fileName = await _fileStore.storeFile(file);
            FileEntity fileEntity = new FileEntity();
            fileEntity.Author = author;
            fileEntity.FileName = fileName;
            fileEntity.UploadDate = DateTime.Now;
            return this._fileRepository.saveFile(fileEntity);
        }

        public bool renameFile(int id, String newName)
        {
            FileEntity fileEntity = this._fileRepository.getFileById(id);
            if (fileEntity != null)
            {
                if(_fileStore.renameFile(fileEntity.FileName, newName) == true)
                {
                    fileEntity.FileName = newName;
                    return this._fileRepository.updateFile(fileEntity);
                }
            }
            throw new NotFoundException("Không tìm thấy file chỉ định");
        }
        public bool deleteFile(int id)
        {
            FileEntity fileEntity = this._fileRepository.getFileById(id);
            if (fileEntity != null)
            {
                bool check = this._fileRepository.deleteFile(fileEntity);
                if (check)
                {
                    this._fileStore.deleteFile(fileEntity.FileName);
                    return true;
                }
            }
            throw new NotFoundException("Không tìm thấy file chỉ định");
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
