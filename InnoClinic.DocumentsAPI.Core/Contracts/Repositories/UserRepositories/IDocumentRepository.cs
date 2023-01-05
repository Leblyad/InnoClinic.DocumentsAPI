using InnoClinic.DocumentsAPI.Core.Entities.Models;

namespace InnoClinic.DocumentsAPI.Core.Contracts.Repositories.UserRepositories
{
    public interface IDocumentRepository
    {
        Task CreateDocumentAsync(Document document);
        Task DeleteDocumentAsync(string documentId);
        Task<Document> GetDocumentAsync(string documentId);
        Task UpdateDocumentAsync(Document document);
    }
}
