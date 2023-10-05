using FileManager.Dto;
using ManageFileBE.Models;
using ManageFileBE.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageFileBE.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService, IFileStore fileStore)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public ActionResult<ICollection<FileEntity>> GetAllFile()
        {
            try
            {
                var files = this._fileService.getAllFile();
                return Ok(files);
            }
            catch (Exception e)
            {
                return NotFound();
            }

        }

        [HttpGet("{id}")]
        public ActionResult<string> GetById(int id)
        {
            try
            {
                var file = this._fileService.getFileById(id);
                return Ok(file);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        [HttpGet("view/{id}")]
        public IActionResult ViewById(int id)
        {
            try
            {
                FileRespon file = this._fileService.viewFileById(id);

                string contentType = "image/jpeg";
                return File(file.FileBytes, file.ContentType);
            }
            catch (Exception e)
            {
                return NotFound("Hình ảnh không tồn tại.");
            }
        }

        //[HttpGet("detail/{id}")]
        //public IActionResult DetailById(int id)
        //{
        //    try
        //    {
        //        Fi
        //    }
        //}

        [HttpPost]
        public IActionResult Post([FromForm] IFormFile file, [FromForm] string author)
        {

            try
            {
                string param1 = author;
                string param2 = file.FileName;
                bool isSave = this._fileService.saveFile(author, file);
                if (isSave == true)
                    return Ok();
                else
                    return StatusCode(500, "An internal server error occurred.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "An internal server error occurred.");
            }
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteFile (int id)
        {

            if (!_fileService.deleteFile(id))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }
            
            return NoContent();
        }
    }
}
