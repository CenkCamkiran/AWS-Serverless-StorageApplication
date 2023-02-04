using AWS_Serverless_StorageApplication.Models;
using MediatR;

namespace AWS_Serverless_StorageApplication.Commands.BucketCommands
{
    public class DeleteBucketCommand : IRequest<BucketResponse>
    {
        public string BucketName { get; set; } = string.Empty;

        public DeleteBucketCommand(string bucketName)
        {
            BucketName = bucketName;
        }
    }
}
