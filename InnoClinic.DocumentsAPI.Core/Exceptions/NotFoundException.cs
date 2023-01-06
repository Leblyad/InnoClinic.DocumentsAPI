namespace InnoClinic.DocumentsAPI.Core.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string message)
            : base(message)
        { }
    }
}
