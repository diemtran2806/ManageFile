using ManageFileBE.Exceptions;
using ManageFileBE.Service.Interface;

namespace ManageFileBE.Service.Impl
{
    public class FileStore : IFileStore
    {
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

        public bool storeFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return false;
            }
            var filePath = Path.Combine(IFileStore._uploadsPath, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyToAsync(stream);
            }
            return true;
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
    }
}
