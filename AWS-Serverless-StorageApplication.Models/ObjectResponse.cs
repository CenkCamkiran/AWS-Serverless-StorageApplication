namespace AWS_Serverless_StorageApplication.Models
{
    public class ObjectResponse : BaseResponse
    {
        public string ObjectName { get; set; } = string.Empty;
        public string BucketName { get; set; } = string.Empty;
    }
}
