using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using InnoClinic.DocumentsAPI.Application.Services.Abstractions;

namespace InnoClinic.DocumentsAPI.Application.Services;

public class UploadService : IUploadService
{
    private readonly BlobServiceClient _blobServiceClient;

    public UploadService(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }

    public async Task<string> UploadAsync(string localFilePath)
    {
        var container = _blobServiceClient.GetBlobContainerClient("blob1");
        var fileName = Path.GetFileName(localFilePath);

        var createResponse = await container.CreateIfNotExistsAsync();
        if (createResponse != null && createResponse.GetRawResponse().Status == 201)
            await container.SetAccessPolicyAsync(PublicAccessType.Blob);

        var blob = container.GetBlobClient(fileName);

        await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
        await blob.UploadAsync(localFilePath, true);

        return blob.Uri.ToString();
    }
}
