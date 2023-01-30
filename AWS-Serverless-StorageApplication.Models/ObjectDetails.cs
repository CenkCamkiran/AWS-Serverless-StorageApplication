namespace AWS_Serverless_StorageApplication.Models
{
    public class ObjectDetails
    {
        public long SizeInBytes { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public Dictionary<string, string> MetaData { get; set; } = new Dictionary<string, string>();
    }
}
