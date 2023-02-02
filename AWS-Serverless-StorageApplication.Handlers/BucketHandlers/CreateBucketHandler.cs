using AWS_Serverless_StorageApplication.Commands.BucketCommands;
using AWS_Serverless_StorageApplication.Repositories.Interfaces;
using MediatR;

namespace AWS_Serverless_StorageApplication.Handlers.BucketHandlers
{
    public class CreateBucketHandler : IRequestHandler<CreateBucketCommand, int>
    {

        private readonly IS3ObjectStorageRepository _s3ObjectStorageRepository;

        public CreateBucketHandler(IS3ObjectStorageRepository s3ObjectStorageRepository)
        {
            _s3ObjectStorageRepository = s3ObjectStorageRepository;
        }

        public async Task<int> Handle(CreateBucketCommand request, CancellationToken cancellationToken)
        {
            return await _s3ObjectStorageRepository.CreateBucket(request.BucketName);
        }
    }
}
