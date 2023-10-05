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

        [HttpDelete("{id}")]
        public IActionResult DeleteFile (int fileId)
        {

            if (!_fileService.deleteFile(fileId))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }
            
            return NoContent();
        }
    }
}
