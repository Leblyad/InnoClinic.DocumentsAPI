namespace InnoClinic.DocumentsAPI.Application.Services.Abstractions
{
    public interface IUploadService
    {
        Task<string> UploadAsync(string fileName);
    }
}
