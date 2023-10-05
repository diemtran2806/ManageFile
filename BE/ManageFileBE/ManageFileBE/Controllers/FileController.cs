using ManageFileBE.Config;
using ManageFileBE.Service.Interface;
using ManageFileBE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FileManager.Dto;

namespace ManageFileBE.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IFileService _fileService;

        public FileController(IFileService fileService)
        {
            this._fileService = fileService;
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

        [HttpPost]
        [Route("upload")]
        public IActionResult UploadFile([FromForm] IFormFile file, [FromForm] string author)
        {
            try
            {
                bool isSave = this._fileService.saveFile(author, file);
                if (isSave)
                    return Ok("File upload successfully");
                else
                    return StatusCode(500, "An internal server error occurred.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "An internal server error occurred.");
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

    }
}
