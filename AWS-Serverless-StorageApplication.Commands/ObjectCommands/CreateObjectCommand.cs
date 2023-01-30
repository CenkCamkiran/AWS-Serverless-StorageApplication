using AWS_Serverless_StorageApplication.Models;
using MediatR;

namespace AWS_Serverless_StorageApplication.Commands.ObjectCommands
{
    public class CreateObjectCommand : IRequest<ObjectDetails>
    {
        public long SizeInBytes { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public Dictionary<string, string> MetaData { get; set; } = new Dictionary<string, string>();

        public CreateObjectCommand(long sizeInBytes, string name, string contentType, DateTime createDate, Dictionary<string, string> metaData)
        {
            SizeInBytes = sizeInBytes;
            Name = name;
            ContentType = contentType;
            CreateDate = createDate;
            MetaData = metaData;
        }
    }
}
