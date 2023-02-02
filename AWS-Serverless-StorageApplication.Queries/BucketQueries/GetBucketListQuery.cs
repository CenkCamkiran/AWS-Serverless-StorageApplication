using Amazon.S3.Model;
using MediatR;

namespace AWS_Serverless_StorageApplication.Queries.BucketQueries
{
    public class GetBucketListQuery : IRequest<List<S3Bucket>>
    {
    }
}
