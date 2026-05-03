namespace College.Api.Exceptions
{
    internal sealed class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }
    }
}
