using AWS_Serverless_StorageApplication.Commands.BucketCommands;
using AWS_Serverless_StorageApplication.Repositories.Interfaces;
using MediatR;

namespace AWS_Serverless_StorageApplication.Handlers.BucketHandlers
{
    public class DeleteBucketHandler : IRequestHandler<DeleteBucketCommand, int>
    {

        private readonly IS3ObjectStorageRepository _s3ObjectStorageRepository;

        public DeleteBucketHandler(IS3ObjectStorageRepository s3ObjectStorageRepository)
        {
            _s3ObjectStorageRepository = s3ObjectStorageRepository;
        }

        public async Task<int> Handle(DeleteBucketCommand request, CancellationToken cancellationToken)
        {
            return await _s3ObjectStorageRepository.DeleteBucket(request.BucketName);
        }
    }
}
