using AWS_Serverless_StorageApplication.Commands.ObjectCommands;
using AWS_Serverless_StorageApplication.Models;
using AWS_Serverless_StorageApplication.Repositories.Interfaces;
using MediatR;

namespace AWS_Serverless_StorageApplication.Handlers.ObjectHandlers
{
    public class UpdateObjectHandler : IRequestHandler<UpdateObjectCommand, string>
    {

        private readonly IS3ObjectStorageRepository _s3ObjectStorageRepository;

        public UpdateObjectHandler(IS3ObjectStorageRepository s3ObjectStorageRepository)
        {
            _s3ObjectStorageRepository = s3ObjectStorageRepository;
        }

        public async Task<string> Handle(UpdateObjectCommand request, CancellationToken cancellationToken)
        {
            ObjectDetails result = await _s3ObjectStorageRepository.GetObject(request.Name);
            if (result == null)
                return await Task.FromResult(string.Empty);

            ObjectDetails fileDetails = new ObjectDetails()
            {
                ContentType = request.ContentType,
                CreateDate = request.CreateDate,
                MetaData = request.MetaData,
                Name = request.Name,
                SizeInBytes = request.SizeInBytes
            };

            return await _s3ObjectStorageRepository.UpdateObject(fileDetails);
        }
    }
}
