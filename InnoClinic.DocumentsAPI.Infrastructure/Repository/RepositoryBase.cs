using Azure.Data.Tables;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using InnoClinic.DocumentsAPI.Core.Contracts.Repositories;
using Microsoft.Extensions.Configuration;

namespace InnoClinic.DocumentsAPI.Infrastructure.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : ITableEntity
    {
        protected readonly TableClient _tableClient;
        private readonly BlobContainerClient _blobContainerClient;

        public RepositoryBase(TableServiceClient tableClient, BlobServiceClient blobClient, IConfiguration config)
        {
            var tableName = config.GetSection("AzureTables:TableStorage").Value;
            var blobName = config.GetSection("AzureTables:BlobStorage").Value;

            _tableClient = tableClient.GetTableClient(tableName);
            tableClient.CreateTableIfNotExists(tableName);
            _blobContainerClient = blobClient.GetBlobContainerClient(blobName);
        }

        public async Task Create(ITableEntity entity) => await _tableClient.AddEntityAsync(entity);

        public async Task Delete(string partitionKey, string rowKey) => await _tableClient.DeleteEntityAsync(partitionKey, rowKey);

        public async Task Update(ITableEntity entity) => await _tableClient.UpsertEntityAsync(entity);

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
