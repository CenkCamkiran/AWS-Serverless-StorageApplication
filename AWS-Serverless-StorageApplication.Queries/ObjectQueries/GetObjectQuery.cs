using Amazon.S3.Model;
using AWS_Serverless_StorageApplication.Models;
using MediatR;

namespace AWS_Serverless_StorageApplication.Queries.ObjectQueries
{
    public class GetObjectQuery : IRequest<GetObjectResponse>
    {
        public string BucketName { get; set; } = string.Empty;
        public string ObjectName { get; set; } = string.Empty;
    }
}
