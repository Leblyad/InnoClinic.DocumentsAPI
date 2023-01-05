using AutoMapper;
using InnoClinic.DocumentsAPI.Application.DataTranferObjects;
using InnoClinic.DocumentsAPI.Core.Entities.Enums;
using InnoClinic.DocumentsAPI.Core.Entities.Models;

namespace InnoClinic.DocumentsAPI.Application.MappingProfiles
{
    public class DocumentMappingProfile : Profile
    {
        public DocumentMappingProfile()
        {
            CreateMap<Document, DocumentDto>().ForMember(src => src.Id, opts => opts.MapFrom(dest => dest.Id.ToString()));

            CreateMap<DocumentForCreationDto, Document>().ForMember(dest => dest.Id, opts => opts.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.PartitionKey, opts => opts.MapFrom(src => FileType.Document.ToString()))
                .AfterMap((src, dest) => dest.RowKey = dest.Id.ToString()); ;

            CreateMap<DocumentForUpdateDto, Document>().ForMember(dest => dest.PartitionKey, opts => opts.MapFrom(src => FileType.Document.ToString()));
        }
    }
}
