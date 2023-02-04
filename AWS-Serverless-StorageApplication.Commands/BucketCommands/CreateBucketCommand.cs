using AWS_Serverless_StorageApplication.Models;
using MediatR;

namespace AWS_Serverless_StorageApplication.Commands.BucketCommands
{
    public class CreateBucketCommand : IRequest<BucketResponse>
    {
        public string BucketName { get; set; } = string.Empty;

        public CreateBucketCommand(string bucketName)
        {
            BucketName = bucketName;
        }
    }
}
