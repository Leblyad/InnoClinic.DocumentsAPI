using Azure.Data.Tables;
using Azure.Storage.Blobs;
using InnoClinic.DocumentsAPI.Core.Contracts.Repositories.UserRepositories;
using InnoClinic.DocumentsAPI.Core.Entities.Enums;
using InnoClinic.DocumentsAPI.Core.Entities.Models;
using Microsoft.Extensions.Configuration;
namespace InnoClinic.DocumentsAPI.Infrastructure.Repository
{
    public class DocumentRepository : RepositoryBase<Document>, IDocumentRepository
    {
        public DocumentRepository(TableServiceClient tableClient, BlobServiceClient blobClient, IConfiguration config)
            : base(tableClient, blobClient, config)
        {
        }

        public async Task CreateDocumentAsync(Document document) => await Create(document);

        public async Task DeleteDocumentAsync(string documentId) => await Delete(nameof(FileType.Document), documentId);

        public async Task<Document> GetDocumentAsync(string documentId) => await _tableClient.GetEntityAsync<Document>(nameof(FileType.Document), documentId);

        public async Task UpdateDocumentAsync(Document document) => await Update(document);

        public async Task<string> UploadDocumentAsync(string fileName, Stream fileStream) => await UploadAsync(fileName, fileStream);

        public async Task<Document> GetDocumentByResultId(Guid resultId) => 
            await _tableClient.QueryAsync<Document>($@"ResultId eq '{resultId}'").FirstOrDefaultAsync();
    }
}
