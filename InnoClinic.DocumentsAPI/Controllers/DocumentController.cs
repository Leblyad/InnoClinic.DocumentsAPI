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

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetDocumentById(Guid id)
        {
            var document = await _documentService.GetDocumentAsync(id);

            return Ok(document);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDocument([FromBody] DocumentForCreationDto documentForCreation)
        {
            var documentDto = await _documentService.CreateDocumentAsync(documentForCreation);

            return CreatedAtAction(nameof(GetDocumentById), new { documentId = documentDto.Id }, documentDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateDocument(Guid id, [FromBody] DocumentForUpdateDto document)
        {
            await _documentService.UpdateDocumentAsync(id, document);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteDocument(Guid id)
        {
            await _documentService.DeleteDocumentAsync(id);

            return NoContent();
        }

        [HttpGet("/ResultId/{resultId:guid}")]
        public async Task<IActionResult> GetDocumentByResultId(Guid resultId)
        {
            var Document = await _documentService.GetDocumentByResultIdAsync(resultId);

            return Ok(Document);
        }
    }
}
