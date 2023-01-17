namespace InnoClinic.DocumentsAPI.Core.Exceptions.UserExceptions
{
    public class PhotoNotFoundException : NotFoundException
    {
        public PhotoNotFoundException(Guid photoId)
            : base($"The photo with the identifier {photoId} was not found.")
        {
        }

        public PhotoNotFoundException(string url)
            : base($"The photo with the url {url} was not found.")
        {
        }
    }
}
