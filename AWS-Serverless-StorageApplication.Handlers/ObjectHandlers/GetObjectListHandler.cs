using Amazon.S3.Model;
using AWS_Serverless_StorageApplication.Models;
using AWS_Serverless_StorageApplication.Queries.ObjectQueries;
using AWS_Serverless_StorageApplication.Repositories.Interfaces;
using MediatR;

namespace AWS_Serverless_StorageApplication.Handlers.ObjectHandlers
{
    public class GetObjectListHandler : IRequestHandler<GetObjectListQuery, List<S3Object>>
    {

        private readonly IS3ObjectStorageRepository _s3ObjectStorageRepository;

        public GetObjectListHandler(IS3ObjectStorageRepository s3ObjectStorageRepository)
        {
            _s3ObjectStorageRepository = s3ObjectStorageRepository;
        }

        public async Task<List<S3Object>> Handle(GetObjectListQuery request, CancellationToken cancellationToken)
        {
            return await _s3ObjectStorageRepository.GetObjectList(request.BucketName);
        }
    }
}
