namespace ManageFileBE.Service.Interface
{
    public interface IFileStore
    {
        public static string _uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        public String storeFile(IFormFile file);
        public bool deleteFile(String fileName);
        public byte[] viewFileByteCode(String fileName);
        public bool renameFile(String oldName, String newName);
    }
}
