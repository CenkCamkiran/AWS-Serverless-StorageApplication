using MediatR;

namespace AWS_Serverless_StorageApplication.Commands.ObjectCommands
{
    public class DeleteObjectCommand : IRequest<int>
    {
        public string BucketName { get; set; } = string.Empty;
        public string ObjectName { get; set; } = string.Empty;

        public DeleteObjectCommand(string bucketName, string objectName)
        {
            BucketName = bucketName;
            ObjectName = objectName;
        }
    }
}
