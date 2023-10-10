using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageFileBE.Models
{
    [Table("Files")]
    public class FileEntity
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(100)]
        public string FileName { get; set; }
        public DateTime UploadDate { get; set; }
        public string Length { get; set; }
        [MaxLength(100)]
        public string Author { get; set; }
    }
}
