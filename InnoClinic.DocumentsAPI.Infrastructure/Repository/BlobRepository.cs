using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using InnoClinic.DocumentsAPI.Core.Contracts.Repositories.UserRepositories;

namespace InnoClinic.DocumentsAPI.Infrastructure.Repository
{
    public class BlobRepository : IBlobRepository
    {
        private readonly BlobContainerClient _blobContainerClient;
        public BlobRepository(BlobServiceClient blobServiceClient)
        {
            _blobContainerClient = blobServiceClient.GetBlobContainerClient("files");
        }

        public async Task<string> UploadAsync(string fileName, Stream fileStream)
        {
            var newFileName = DateTime.UtcNow.ToString("O") + "_" + fileName;
            var blob = _blobContainerClient.GetBlobClient(newFileName);
            await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
            await blob.UploadAsync(fileStream);
            return blob.Uri.ToString();
        }
    }
}
