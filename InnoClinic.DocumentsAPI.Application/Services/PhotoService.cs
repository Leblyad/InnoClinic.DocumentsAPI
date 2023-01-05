using AutoMapper;
using InnoClinic.DocumentsAPI.Application.DataTranferObjects;
using InnoClinic.DocumentsAPI.Application.Services.Abstractions;
using InnoClinic.DocumentsAPI.Core.Contracts.Repositories.UserRepositories;
using InnoClinic.DocumentsAPI.Core.Entities.Models;

namespace InnoClinic.DocumentsAPI.Application.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IMapper _mapper;
        public PhotoService(IPhotoRepository photoRepository, IMapper mapper)
        {
            _photoRepository = photoRepository;
            _mapper = mapper;
        }

        public async Task<PhotoDto> CreatePhotoAsync(PhotoForCreationDto photo)
        {
            var photoEntity = _mapper.Map<Photo>(photo);
            await _photoRepository.CreatePhotoAsync(photoEntity);

            return _mapper.Map<PhotoDto>(photoEntity);
        }

        public async Task DeletePhotoAsync(Guid photoId)
        {
            await _photoRepository.DeletePhotoAsync(photoId.ToString());
        }

        public async Task<PhotoDto> GetPhotoAsync(Guid photoId)
        {
            var photo = await _photoRepository.GetPhotoAsync(photoId.ToString());

            return _mapper.Map<PhotoDto>(photo);
        }

        public async Task UpdatePhotoAsync(Guid photoId, PhotoForUpdateDto photo)
        {
            var photoEntity = _mapper.Map<Photo>(photo);
            photoEntity.Id = photoId;
            photoEntity.RowKey = photoId.ToString();

            await _photoRepository.UpdatePhotoAsync(photoEntity);
        }
    }
}
