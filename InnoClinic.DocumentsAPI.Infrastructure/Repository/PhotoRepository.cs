using Azure.Data.Tables;
using InnoClinic.DocumentsAPI.Core.Contracts.Repositories.UserRepositories;
using InnoClinic.DocumentsAPI.Core.Entities.Enums;
using InnoClinic.DocumentsAPI.Core.Entities.Models;

namespace InnoClinic.DocumentsAPI.Infrastructure.Repository
{
    public class PhotoRepository : RepositoryBase<Photo>, IPhotoRepository
    {
        public PhotoRepository(TableServiceClient tableServiceClient) : base(tableServiceClient)
        {
        }

        public async Task CreatePhotoAsync(Photo photo) => await Create(photo);

        public async Task DeletePhotoAsync(string photoId) => await Delete(nameof(FileType.Photo), photoId);

        public async Task<Photo> GetPhotoAsync(string photoId) => await _tableClient.GetEntityAsync<Photo>(nameof(FileType.Photo), photoId);

        public async Task UpdatePhotoAsync(Photo photo) => await Update(photo);
    }
}
