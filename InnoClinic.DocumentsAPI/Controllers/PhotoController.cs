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

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPhotoById(Guid id)
        {
            var photo = await _photoService.GetPhotoAsync(id);

            return Ok(photo);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePhoto([FromBody] PhotoForCreationDto photoForCreation)
        {
            var photoDto = await _photoService.CreatePhotoAsync(photoForCreation);

            return CreatedAtAction(nameof(GetPhotoById), new { photoId = photoDto.Id }, photoDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdatePhoto(Guid id, [FromBody] PhotoForUpdateDto photo)
        {
            await _photoService.UpdatePhotoAsync(id, photo);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletePhoto(Guid id)
        {
            await _photoService.DeletePhotoAsync(id);

            return NoContent();
        }
    }
}
