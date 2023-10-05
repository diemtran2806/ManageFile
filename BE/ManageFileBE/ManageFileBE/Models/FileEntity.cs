using System.ComponentModel.DataAnnotations;

namespace ManageFileBE.Models
{
    public class FileEntity
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime UploadDate { get; set; }
        public string Author { get; set; }
    }
}
