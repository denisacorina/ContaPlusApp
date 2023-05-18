using ContaPlusAPI.Interfaces.IService;
using ContaPlusAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContaPlusAPI.Controllers
{
    public class ImagesController : BaseApiController
    {
        private readonly IPhotoService _photosService;

        public ImagesController(IPhotoService photosService)
        {
            _photosService = photosService;
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> Get(string fileName)
        {
            var picture = await _photosService.GetPictureAsync(fileName);
            if (picture != null)
            {
                return File(picture, "image/jpeg");
            }
            else
            {
                return NotFound("Picture not found.");
            }
        }

        [HttpPost("{pictureType}/{referenceId}")]
        [Produces("multipart/form-data")]
        public async Task<IActionResult> UploadPicture(string pictureType, Guid referenceId, [FromForm] IFormFile file)
        {
            if (string.IsNullOrWhiteSpace(pictureType))
            {
                return BadRequest("Invalid picture type.");
            }

            file = Request.Form.Files.FirstOrDefault();
            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid file.");
            }

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (!allowedExtensions.Contains(fileExtension))
            {
                return BadRequest("Invalid file type. Only JPEG and PNG images are allowed.");
            }

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var picture = ms.ToArray();
                var fileName = await _photosService.UploadPictureAsync(file.FileName, picture, pictureType, referenceId);
                return Ok(fileName);
            }
        }

        [HttpDelete("{fileName}")]
        public async Task<IActionResult> Delete(string fileName)
        {
            var success = await _photosService.DeletePictureAsync(fileName);
            if (success)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}

