using AutoMapper;
using InnoClinic.DocumentsAPI.Application.DataTranferObjects;
using InnoClinic.DocumentsAPI.Core.Entities.Enums;
using InnoClinic.DocumentsAPI.Core.Entities.Models;

namespace InnoClinic.DocumentsAPI.Application.MappingProfiles
{
    public class PhotoMappingProfile : Profile
    {
        public PhotoMappingProfile()
        {
            CreateMap<Photo, PhotoDto>().ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id.ToString()));

            CreateMap<PhotoForCreationDto, Photo>().ForMember(dest => dest.Id, opts => opts.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.PartitionKey, opts => opts.MapFrom(src => FileType.Photo.ToString()))
                .AfterMap((src, dest) => dest.RowKey = dest.Id.ToString());

            CreateMap<PhotoForUpdateDto, Photo>().ForMember(dest => dest.PartitionKey, opts => opts.MapFrom(src => FileType.Photo.ToString()));
        }
    }
}
