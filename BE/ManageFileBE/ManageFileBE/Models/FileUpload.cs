using System.ComponentModel.DataAnnotations;

namespace ManageFileBE.Models
{
    public class FileUpload
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Date { get; set; }
        public string Author { get; set; }
    }
}
