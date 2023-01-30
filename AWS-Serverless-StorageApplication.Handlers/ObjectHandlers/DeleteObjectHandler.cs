using AWS_Serverless_StorageApplication.Commands.ObjectCommands;
using AWS_Serverless_StorageApplication.Models;
using AWS_Serverless_StorageApplication.Repositories.Interfaces;
using MediatR;

namespace AWS_Serverless_StorageApplication.Handlers.ObjectHandlers
{
    public class DeleteObjectHandler : IRequestHandler<DeleteObjectCommand, string>
    {

        private readonly IS3ObjectStorageRepository _s3ObjectStorageRepository;

        public DeleteObjectHandler(IS3ObjectStorageRepository s3ObjectStorageRepository)
        {
            _s3ObjectStorageRepository = s3ObjectStorageRepository;
        }

        public async Task<string> Handle(DeleteObjectCommand request, CancellationToken cancellationToken)
        {
            ObjectDetails fileDetails = await _s3ObjectStorageRepository.GetObject(request.Name);
            if (fileDetails == null)
                return await Task.FromResult(string.Empty);

            return await _s3ObjectStorageRepository.DeleteObject(request.Name);
        }
    }
}
