namespace ManageFileBE.Service.Interface
{
    public interface IFileStore
    {
        public static string _uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
        public bool storeFile(IFormFile file);
        public bool deleteFile(String fileName);
        public byte[] viewFileByteCode(String fileName);
    }
}
