using InnoClinic.DocumentsAPI.Application.DataTranferObjects;
using InnoClinic.DocumentsAPI.Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinic.DocumentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpGet("{photoId:guid}")]
        public async Task<IActionResult> GetPhotoById(Guid photoId)
        {
            var photo = await _photoService.GetPhotoAsync(photoId);

            return Ok(photo);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePhoto([FromBody] PhotoForCreationDto photoForCreation)
        {
            var photoDto = await _photoService.CreatePhotoAsync(photoForCreation);

            return CreatedAtAction(nameof(GetPhotoById), new { photoId = photoDto.Id }, photoDto);
        }

        [HttpPut("{photoId:guid}")]
        public async Task<IActionResult> UpdatePhoto(Guid photoId, [FromBody] PhotoForUpdateDto photo)
        {
            await _photoService.UpdatePhotoAsync(photoId, photo);

            return NoContent();
        }

        [HttpDelete("{photoId:guid}")]
        public async Task<IActionResult> DeletePhoto(Guid photoId)
        {
            await _photoService.DeletePhotoAsync(photoId);

            return NoContent();
        }
    }
}
