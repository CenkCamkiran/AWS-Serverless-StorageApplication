using AWS_Serverless_StorageApplication.Commands.ObjectCommands;
using AWS_Serverless_StorageApplication.Models;
using AWS_Serverless_StorageApplication.Repositories.Interfaces;
using MediatR;

namespace AWS_Serverless_StorageApplication.Handlers.ObjectHandlers
{
    public class CreateObjectHandler : IRequestHandler<CreateObjectCommand, ObjectDetails>
    {

        private readonly IS3ObjectStorageRepository _s3ObjectStorageRepository;

        public CreateObjectHandler(IS3ObjectStorageRepository s3ObjectStorageRepository)
        {
            _s3ObjectStorageRepository = s3ObjectStorageRepository;
        }

        public async Task<ObjectDetails> Handle(CreateObjectCommand request, CancellationToken cancellationToken)
        {
            ObjectDetails fileDetails = new ObjectDetails()
            {
                SizeInBytes = request.SizeInBytes,
                ContentType = request.ContentType,
                CreateDate = request.CreateDate,
                MetaData = request.MetaData,
                Name = request.Name
            };

            return await _s3ObjectStorageRepository.CreateObject(fileDetails);
        }
    }
}
