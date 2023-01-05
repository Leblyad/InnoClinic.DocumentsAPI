

using Azure.Data.Tables;

namespace InnoClinic.DocumentsAPI.Core.Contracts.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task Create(ITableEntity entity);
        Task Delete(string partitionKey, string rowKey);
        Task Update(ITableEntity entity);
    }
}
