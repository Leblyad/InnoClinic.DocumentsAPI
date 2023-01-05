using Azure.Data.Tables;
using InnoClinic.DocumentsAPI.Core.Contracts.Repositories.UserRepositories;
using InnoClinic.DocumentsAPI.Core.Entities.Enums;
using InnoClinic.DocumentsAPI.Core.Entities.Models;

namespace InnoClinic.DocumentsAPI.Infrastructure.Repository
{
    public class DocumentRepository : RepositoryBase<Document>, IDocumentRepository
    {
        public DocumentRepository(TableServiceClient tableServiceClient) : base(tableServiceClient)
        {
        }

        public async Task CreateDocumentAsync(Document document) => await Create(document);

        public async Task DeleteDocumentAsync(string documentId) => await Delete(nameof(FileType.Document), documentId);

        public async Task<Document> GetDocumentAsync(string documentId) => await _tableClient.GetEntityAsync<Document>(nameof(FileType.Document), documentId);

        public async Task UpdateDocumentAsync(Document document) => await Update(document);
    }
}
