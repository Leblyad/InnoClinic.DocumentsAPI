using AutoMapper;
using InnoClinic.DocumentsAPI.Application.DataTranferObjects;
using InnoClinic.DocumentsAPI.Application.Services.Abstractions;
using InnoClinic.DocumentsAPI.Core.Contracts.Repositories.UserRepositories;
using InnoClinic.DocumentsAPI.Core.Entities.Models;
using InnoClinic.DocumentsAPI.Core.Exceptions;
using InnoClinic.DocumentsAPI.Core.Exceptions.UserExceptions;

namespace InnoClinic.DocumentsAPI.Application.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;
        public DocumentService(IDocumentRepository documentRepository, IMapper mapper)
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
        }

        public async Task<DocumentDto> CreateDocumentAsync(DocumentForCreationDto document)
        {
            if (document == null)
            {
                throw new CustomNullReferenceException(typeof(DocumentForCreationDto));
            }

            var url = await _documentRepository.UploadDocumentAsync(document.FileName, new MemoryStream(document.Value));

            if (url == null)
            {
                throw new DocumentNotFoundException(url);
            }

            var documentEntity = _mapper.Map<Document>(document);
            documentEntity.Url = url;
            await _documentRepository.CreateDocumentAsync(documentEntity);

            return _mapper.Map<DocumentDto>(documentEntity);
        }

        public async Task DeleteDocumentAsync(Guid documentId)
        {
            await _documentRepository.DeleteDocumentAsync(documentId.ToString());
        }

        public async Task<DocumentDto> GetDocumentAsync(Guid documentId)
        {
            var document = await _documentRepository.GetDocumentAsync(documentId.ToString());

            if (document == null)
            {
                throw new DocumentNotFoundException(documentId);
            }

            return _mapper.Map<DocumentDto>(document);
        }

        public async Task<DocumentDto> GetDocumentByResultIdAsync(Guid resultId)
        {
            var document = await _documentRepository.GetDocumentByResultId(resultId);

            if (document == null)
            {
                throw new DocumentNotFoundException(resultId);
            }

            return _mapper.Map<DocumentDto>(document);
        }

        public async Task UpdateDocumentAsync(Guid documentId, DocumentForUpdateDto document)
        {
            if (document == null)
            {
                throw new CustomNullReferenceException(typeof(DocumentForUpdateDto));
            }

            var documentEntity = _mapper.Map<Document>(document);
            documentEntity.Id = documentId;
            documentEntity.RowKey = documentId.ToString();

            await _documentRepository.UpdateDocumentAsync(documentEntity);
        }
    }
}
