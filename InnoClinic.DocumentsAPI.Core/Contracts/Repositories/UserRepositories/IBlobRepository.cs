namespace InnoClinic.DocumentsAPI.Core.Contracts.Repositories.UserRepositories
{
    public interface IBlobRepository
    {
        public Task<string> UploadAsync(string fileName, Stream fileStream);
    }
}
