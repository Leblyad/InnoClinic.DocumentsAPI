using InnoClinic.DocumentsAPI.Application.DataTranferObjects;
using InnoClinic.DocumentsAPI.Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinic.DocumentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet("{documentId:guid}")]
        public async Task<IActionResult> GetDocumentById(Guid documentId)
        {
            var document = await _documentService.GetDocumentAsync(documentId);

            return Ok(document);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDocument([FromBody] DocumentForCreationDto documentForCreation)
        {
            var documentDto = await _documentService.CreateDocumentAsync(documentForCreation);

            return CreatedAtAction(nameof(GetDocumentById), new { documentId = documentDto.Id }, documentDto);
        }

        [HttpPut("{documentId:guid}")]
        public async Task<IActionResult> UpdateDocument(Guid documentId, [FromBody] DocumentForUpdateDto document)
        {
            await _documentService.UpdateDocumentAsync(documentId, document);

            return NoContent();
        }

        [HttpDelete("{documentId:guid}")]
        public async Task<IActionResult> DeleteDocument(Guid documentId)
        {
            await _documentService.DeleteDocumentAsync(documentId);

            return NoContent();
        }
    }
}
