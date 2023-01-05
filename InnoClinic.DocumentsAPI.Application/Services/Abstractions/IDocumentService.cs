using InnoClinic.DocumentsAPI.Application.DataTranferObjects;

namespace InnoClinic.DocumentsAPI.Application.Services.Abstractions
{
    public interface IDocumentService
    {
        Task<DocumentDto> CreateDocumentAsync(DocumentForCreationDto document);
        Task DeleteDocumentAsync(Guid documentId);
        Task<DocumentDto> GetDocumentAsync(Guid documentId);
        Task UpdateDocumentAsync(Guid documentId, DocumentForUpdateDto document);
    }
}
