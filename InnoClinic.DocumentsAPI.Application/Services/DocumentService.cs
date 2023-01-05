using AutoMapper;
using InnoClinic.DocumentsAPI.Application.DataTranferObjects;
using InnoClinic.DocumentsAPI.Application.Services.Abstractions;
using InnoClinic.DocumentsAPI.Core.Contracts.Repositories.UserRepositories;
using InnoClinic.DocumentsAPI.Core.Entities.Models;

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
            var documentEntity = _mapper.Map<Document>(document);
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

            return _mapper.Map<DocumentDto>(document);
        }

        public async Task UpdateDocumentAsync(Guid documentId, DocumentForUpdateDto document)
        {
            var documentEntity = _mapper.Map<Document>(document);
            documentEntity.Id = documentId;
            documentEntity.RowKey = documentId.ToString();

            await _documentRepository.UpdateDocumentAsync(documentEntity);
        }
    }
}
