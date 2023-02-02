namespace AWS_Serverless_StorageApplication.Helpers
{
    public class StorageApplicationException : Exception
    {
        public StorageApplicationException()
        {
        }

        public StorageApplicationException(string? message) : base(message)
        {
        }
    }
}
