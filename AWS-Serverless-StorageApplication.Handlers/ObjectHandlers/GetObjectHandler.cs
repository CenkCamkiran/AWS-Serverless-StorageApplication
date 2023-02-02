using Amazon.S3.Model;
using AWS_Serverless_StorageApplication.Models;
using AWS_Serverless_StorageApplication.Queries.ObjectQueries;
using AWS_Serverless_StorageApplication.Repositories.Interfaces;
using MediatR;

namespace AWS_Serverless_StorageApplication.Handlers.ObjectHandlers
{
    public class GetObjectHandler : IRequestHandler<GetObjectQuery, GetObjectResponse>
    {

        private readonly IS3ObjectStorageRepository _s3ObjectStorageRepository;

        public GetObjectHandler(IS3ObjectStorageRepository s3ObjectStorageRepository)
        {
            _s3ObjectStorageRepository = s3ObjectStorageRepository;
        }

        public async Task<GetObjectResponse> Handle(GetObjectQuery request, CancellationToken cancellationToken)
        {
            return await _s3ObjectStorageRepository.GetObject(request.BucketName, request.ObjectName);
        }
    }
}
