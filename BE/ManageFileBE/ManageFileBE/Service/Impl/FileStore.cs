using ManageFileBE.Exceptions;
using ManageFileBE.Service.Interface;

namespace ManageFileBE.Service.Impl
{
    public class FileStore : IFileStore
    {

        public String storeFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new NotFoundException("Không tìm thấy file");
            }
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);
            var fileExtension = Path.GetExtension(file.FileName);

            var existingFiles = Directory.GetFiles(IFileStore._uploadsPath, $"{fileNameWithoutExtension}*{fileExtension}");
            int highestFileCount = existingFiles.Length;

            String fileName = $"{fileNameWithoutExtension} ({highestFileCount}){fileExtension}";
            var filePath = Path.Combine(IFileStore._uploadsPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyToAsync(stream);
            }
            return fileName;
        }

        public byte[] viewFileByteCode(string fileName)
        {

            string filePath = Path.Combine(IFileStore._uploadsPath, fileName);
            if (File.Exists(filePath))
            {
                byte[] fileBytes = File.ReadAllBytes(filePath);
                return fileBytes;
            }
            else
            {
                throw new NotFoundException("Hình ảnh không tồn tại.");
            }
        }
        public bool renameFile(String oldName, String newName)
        {
            String oldPath = Path.Combine(IFileStore._uploadsPath, oldName);
            String newPath = Path.Combine(IFileStore._uploadsPath, newName);
            if (File.Exists(oldPath))
            {
                if (!File.Exists(newPath))
                {
                    File.Move(oldPath, newPath);
                    return true;
                }
                else throw new IOException("File đã tồn tại. Không thể đổi tên!");
                
            }
            else
                throw new NotFoundException("File không tồn tại");
        }
        public bool deleteFile(string fileName)
        {
            string filePath = Path.Combine(IFileStore._uploadsPath, fileName);
            if (File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                return true;
            }
            else
            {
                throw new NotFoundException("Không tìm thấy tệp tin.");
            }
        }


    }
}
