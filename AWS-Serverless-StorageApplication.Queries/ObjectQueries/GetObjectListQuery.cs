using Amazon.S3.Model;
using AWS_Serverless_StorageApplication.Models;
using MediatR;

namespace AWS_Serverless_StorageApplication.Queries.ObjectQueries
{
    public class GetObjectListQuery : IRequest<List<S3Object>>
    {
        public string BucketName { get; set; }

        public GetObjectListQuery(string bucketName)
        {
            BucketName = bucketName;
        }
    }
}
