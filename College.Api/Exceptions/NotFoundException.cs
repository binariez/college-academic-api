namespace College.Api.Exceptions
{
    internal sealed class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
