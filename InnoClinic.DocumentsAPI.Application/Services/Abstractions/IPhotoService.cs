using InnoClinic.DocumentsAPI.Application.DataTranferObjects;

namespace InnoClinic.DocumentsAPI.Application.Services.Abstractions
{
    public interface IPhotoService
    {
        Task<PhotoDto> CreatePhotoAsync(PhotoForCreationDto photo);
        Task DeletePhotoAsync(Guid photoId);
        Task<PhotoDto> GetPhotoAsync(Guid photoId);
        Task UpdatePhotoAsync(Guid photoId, PhotoForUpdateDto photo);
    }
}
