
﻿using ManageFileBE.Models;
using ManageFileBE.Service.Interface;
using ManageFileBE.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ManageFileBE.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IFileService _fileService;
        public FileController(IFileService fileService)
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
                return File(file.FileBytes, file.ContentType);
            }
            catch (Exception e)
            {
                return NotFound("File không tồn tại.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] IFormFile file, [FromForm] string author)
        {
            try
            {
                string param1 = author;
                string param2 = file.FileName;
                bool isSave = await this._fileService.saveFileAsync(author, file);
                if (isSave == true)
                    return Ok("Upload Ok");
                else
                    return StatusCode(500, "An internal server error occurred.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, "An internal server error occurred.");
            }
        }
        [HttpPut("{id}")]
        public IActionResult renameFile(int id, [FromBody] string newName)
        {
            try
            {
                bool isUpdate = this._fileService.renameFile(id, newName);
                if (isUpdate == true)
                    return Ok("Upload Ok");
                else
                    return StatusCode(500, "An internal server error occurred.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, "An internal server error occurred.");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var check = this._fileService.deleteFile(id);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }
}
