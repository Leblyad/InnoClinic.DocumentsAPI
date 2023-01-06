using Azure.Data.Tables;
using InnoClinic.DocumentsAPI.Core.Contracts.Repositories;

namespace InnoClinic.DocumentsAPI.Infrastructure.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : ITableEntity
    {
        protected readonly TableClient _tableClient;
        public RepositoryBase(TableServiceClient tableServiceClient)
        {
            _tableClient = tableServiceClient.GetTableClient("Files");
            tableServiceClient.CreateTableIfNotExists("Files");
        }

        public async Task Create(ITableEntity entity) => await _tableClient.AddEntityAsync(entity);

        public async Task Delete(string partitionKey, string rowKey) => await _tableClient.DeleteEntityAsync(partitionKey, rowKey);

        public async Task Update(ITableEntity entity) => await _tableClient.UpsertEntityAsync(entity);
    }
}
