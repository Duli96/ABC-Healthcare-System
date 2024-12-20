using Microsoft.AspNetCore.Mvc;
using ImageService.Services;
using Shared.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageService.Controllers
{
    [Route("api/image")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages()
        {
            var images = await _imageService.GetImagesAsync();
            return Ok(images);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImage(int id)
        {
            var image = await _imageService.GetImageByIdAsync(id);
            if (image == null) return NotFound();
            return Ok(image);
        }

        [HttpPost("upload")]
        public async Task<ActionResult<Image>> UploadImage(IFormFile file, int patientId, int imageTypeId, string imageType)
        {
            var uploadedImage = await _imageService.UploadImageAsync(file, patientId, imageTypeId, imageType);
            return CreatedAtAction(nameof(GetImage), new { id = uploadedImage.Id }, uploadedImage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var success = await _imageService.DeleteImageAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
