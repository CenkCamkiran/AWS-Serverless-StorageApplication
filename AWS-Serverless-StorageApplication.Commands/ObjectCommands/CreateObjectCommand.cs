using AWS_Serverless_StorageApplication.Models;
using MediatR;

namespace AWS_Serverless_StorageApplication.Commands.ObjectCommands
{
    public class CreateObjectCommand : IRequest<int>
    {
        public string BucketName { get; set; } = string.Empty;
        public ObjectDetails ObjectDetails { get; set; }
        public Stream ObjectStream { get; set; }

        public CreateObjectCommand(string bucketName, ObjectDetails objectDetails, Stream objectStream)
        {
            BucketName = bucketName;
            ObjectDetails = objectDetails;
            ObjectStream = objectStream;
        }
    }
}
