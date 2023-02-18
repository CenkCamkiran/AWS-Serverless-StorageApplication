namespace AWS_Serverless_StorageApplication.Models
{
    public class AWSCredentials
    {
        public string AccessKey { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;
        public string FileLengthLimit { get; set; } = string.Empty;
    }
}
