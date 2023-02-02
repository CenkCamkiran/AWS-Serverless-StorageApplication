namespace AWS_Serverless_StorageApplication.Models
{
    public class BaseResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseDescription { get; set; } = string.Empty;
    }
}
