using Azure.Data.Tables;
using Azure.Storage.Blobs;
using InnoClinic.DocumentsAPI.Core.Contracts.Repositories.UserRepositories;
using InnoClinic.DocumentsAPI.Core.Entities.Enums;
using InnoClinic.DocumentsAPI.Core.Entities.Models;
using Microsoft.Extensions.Configuration;

namespace InnoClinic.DocumentsAPI.Infrastructure.Repository
{
    public class PhotoRepository : RepositoryBase<Photo>, IPhotoRepository
    {
        public PhotoRepository(TableServiceClient tableClient, BlobServiceClient blobClient, IConfiguration config)
            : base(tableClient, blobClient, config)
        {
        }

        public async Task CreatePhotoAsync(Photo photo) => await Create(photo);

        public async Task DeletePhotoAsync(string photoId) => await Delete(nameof(FileType.Photo), photoId);

        public async Task<Photo> GetPhotoAsync(string photoId) => await _tableClient.GetEntityAsync<Photo>(nameof(FileType.Photo), photoId);

        public async Task UpdatePhotoAsync(Photo photo) => await Update(photo);

        public async Task<string> UploadPhotoAsync(string fileName, Stream fileStream) => await UploadAsync(fileName, fileStream);

        public async Task<IEnumerable<Photo>> GetPhotosAsync(IEnumerable<Guid> ids)
        {
            List<Photo> photos = new List<Photo>();
            for (int i = 0; i < ids.Count(); i++)
            {
                var photo = await _tableClient.GetEntityAsync<Photo>(nameof(FileType.Photo), ids.ElementAt(i).ToString());
                photos.Add(photo);
            }
            return photos;
        }
    }
}
