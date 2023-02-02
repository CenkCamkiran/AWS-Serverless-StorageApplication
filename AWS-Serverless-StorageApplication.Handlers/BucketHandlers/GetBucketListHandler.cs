using Amazon.S3.Model;
using AWS_Serverless_StorageApplication.Commands.ObjectCommands;
using AWS_Serverless_StorageApplication.Queries.BucketQueries;
using AWS_Serverless_StorageApplication.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Serverless_StorageApplication.Handlers.BucketHandlers
{
    public class GetBucketListHandler : IRequestHandler<GetBucketListQuery, List<S3Bucket>>
    {

        private readonly IS3ObjectStorageRepository _s3ObjectStorageRepository;

        public GetBucketListHandler(IS3ObjectStorageRepository s3ObjectStorageRepository)
        {
            _s3ObjectStorageRepository = s3ObjectStorageRepository;
        }

        public async Task<List<S3Bucket>> Handle(GetBucketListQuery request, CancellationToken cancellationToken)
        {
            return await _s3ObjectStorageRepository.ListBuckets();
        }
    }
}
