using InnoClinic.DocumentsAPI.Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinic.DocumentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IUploadService uploadService;

        public UploadController(IUploadService uploadService)
        {
            this.uploadService = uploadService ?? throw new ArgumentNullException(nameof(uploadService));
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadAsync([FromQuery] string localFilePath)
        {
            string fileURL = await uploadService.UploadAsync(localFilePath);

            return Ok(new { fileURL });
        }
    }
}
