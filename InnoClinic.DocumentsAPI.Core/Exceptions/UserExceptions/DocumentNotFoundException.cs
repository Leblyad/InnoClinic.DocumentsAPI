namespace InnoClinic.DocumentsAPI.Core.Exceptions.UserExceptions
{
    public class DocumentNotFoundException : NotFoundException
    {
        public DocumentNotFoundException(Guid documentId)
            : base($"The document with the identifier {documentId} was not found.")
        {
        }

        public DocumentNotFoundException(string url)
            : base($"The document with the url {url} was not found.")
        {
        }
    }
}
