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


        [HttpPost("collection")]
        public async Task<IActionResult> GetPhotosByIds([FromBody] IEnumerable<Guid> ids)
        {
            var photo = await _photoService.GetPhotosAsync(ids);

            return Ok(photo);
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
            byte[] imageByteArray = null;
            FileStream fileStream = new FileStream(@"C:\\Users\\apk59\\Downloads\\Glenn_greenwald_portrait_transparent.png", FileMode.Open, FileAccess.Read);
            using (BinaryReader reader = new BinaryReader(fileStream))
            {
                imageByteArray = new byte[reader.BaseStream.Length];
                for (int i = 0; i < reader.BaseStream.Length; i++)
                    imageByteArray[i] = reader.ReadByte();
            }

            photoForCreation.Value = imageByteArray;
            photoForCreation.FileName = "Glenn_greenwald_portrait_transparent.png";

            var photoDto = await _photoService.CreatePhotoAsync(photoForCreation);

            return CreatedAtAction(nameof(GetPhotoById), new { id = photoDto.Id }, photoDto);
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
