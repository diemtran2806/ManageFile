namespace ManageFileBE.Service.Interface
{
    public interface IFileStore
    {
        public static string _uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
        public bool saveFile(IFormFile file);
        public byte[] readFileByName(String name);
        public bool deleteFile(String name);
    }
}
