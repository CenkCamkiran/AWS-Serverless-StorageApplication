using Amazon.Runtime.Internal;
using Amazon.S3.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Serverless_StorageApplication.Queries.BucketQueries
{
    public class GetBucketListQuery: IRequest<List<S3Bucket>>
    {
    }
}
