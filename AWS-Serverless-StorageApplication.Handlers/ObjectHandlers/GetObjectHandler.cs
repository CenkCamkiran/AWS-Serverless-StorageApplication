using AWS_Serverless_StorageApplication.Models;
using AWS_Serverless_StorageApplication.Queries.ObjectQueries;
using AWS_Serverless_StorageApplication.Repositories.Interfaces;
using MediatR;

namespace AWS_Serverless_StorageApplication.Handlers.ObjectHandlers
{
    public class GetObjectHandler : IRequestHandler<GetObjectQuery, ObjectDetails>
    {

        private readonly IS3ObjectStorageRepository _s3ObjectStorageRepository;

        public GetObjectHandler(IS3ObjectStorageRepository s3ObjectStorageRepository)
        {
            _s3ObjectStorageRepository = s3ObjectStorageRepository;
        }

        public async Task<ObjectDetails> Handle(GetObjectQuery request, CancellationToken cancellationToken)
        {
            return await _s3ObjectStorageRepository.GetObjectByGuid(request.Guid);
        }
    }
}
