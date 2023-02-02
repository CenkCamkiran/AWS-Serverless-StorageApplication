using AWS_Serverless_StorageApplication.Commands.ObjectCommands;
using AWS_Serverless_StorageApplication.Models;
using AWS_Serverless_StorageApplication.Repositories.Interfaces;
using MediatR;

namespace AWS_Serverless_StorageApplication.Handlers.ObjectHandlers
{
    public class CreateObjectHandler : IRequestHandler<CreateObjectCommand, int>
    {

        private readonly IS3ObjectStorageRepository _s3ObjectStorageRepository;

        public CreateObjectHandler(IS3ObjectStorageRepository s3ObjectStorageRepository)
        {
            _s3ObjectStorageRepository = s3ObjectStorageRepository;
        }

        public async Task<int> Handle(CreateObjectCommand request, CancellationToken cancellationToken)
        {
            ObjectDetails objectInfo = new ObjectDetails()
            {
                SizeInBytes = request.ObjectDetails.SizeInBytes,
                ContentType = request.ObjectDetails.ContentType,
                CreateDate = request.ObjectDetails.CreateDate,
                MetaData = request.ObjectDetails.MetaData,
                Name = request.ObjectDetails.Name
            };

            return await _s3ObjectStorageRepository.CreateObject(request.BucketName, objectInfo, request.ObjectStream);
        }
    }
}
