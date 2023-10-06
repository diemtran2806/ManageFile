<<<<<<< HEAD
﻿using FileManager.Dto;
using ManageFileBE.Models;
using ManageFileBE.Service.Interface;
using Microsoft.AspNetCore.Http;
=======

﻿using ManageFileBE.Models;
using ManageFileBE.Service.Interface;
using ManageFileBE.Dto;
>>>>>>> dfe0722ed57857e90703b368c4b58c50fd15a953
using Microsoft.AspNetCore.Mvc;

namespace ManageFileBE.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {
<<<<<<< HEAD
        private readonly IFileService _fileService;
        public FileController(IFileService fileService, IFileStore fileStore)
=======
        private IFileService _fileService;
        public FileController(IFileService fileService)
>>>>>>> dfe0722ed57857e90703b368c4b58c50fd15a953
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
<<<<<<< HEAD

                string contentType = "image/jpeg";
=======
>>>>>>> dfe0722ed57857e90703b368c4b58c50fd15a953
                return File(file.FileBytes, file.ContentType);
            }
            catch (Exception e)
            {
<<<<<<< HEAD
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

=======
                return NotFound("File không tồn tại.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] IFormFile file, [FromForm] string author)
        {
>>>>>>> dfe0722ed57857e90703b368c4b58c50fd15a953
            try
            {
                string param1 = author;
                string param2 = file.FileName;
<<<<<<< HEAD
                bool isSave = this._fileService.saveFile(author, file);
                if (isSave == true)
                    return Ok();
=======
                bool isSave = await this._fileService.saveFileAsync(author, file);
                if (isSave == true)
                    return Ok("Upload Ok");
>>>>>>> dfe0722ed57857e90703b368c4b58c50fd15a953
                else
                    return StatusCode(500, "An internal server error occurred.");
            }
            catch (Exception e)
            {
<<<<<<< HEAD
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
=======
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
>>>>>>> dfe0722ed57857e90703b368c4b58c50fd15a953
        }
    }
}
