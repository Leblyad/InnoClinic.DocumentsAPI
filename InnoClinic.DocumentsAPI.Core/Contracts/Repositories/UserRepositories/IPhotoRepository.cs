using InnoClinic.DocumentsAPI.Core.Entities.Models;

namespace InnoClinic.DocumentsAPI.Core.Contracts.Repositories.UserRepositories
{
    public interface IPhotoRepository
    {
        Task CreatePhotoAsync(Photo photo);
        Task DeletePhotoAsync(string photoId);
        Task<Photo> GetPhotoAsync(string photoId);
        Task UpdatePhotoAsync(Photo photo);
    }
}
