using AWS_Serverless_StorageApplication.Commands.ObjectCommands;
using AWS_Serverless_StorageApplication.Repositories.Interfaces;
using MediatR;
using System.Net;

namespace AWS_Serverless_StorageApplication.Handlers.ObjectHandlers
{
    public class DeleteObjectHandler : IRequestHandler<DeleteObjectCommand, int>
    {

        private readonly IS3ObjectStorageRepository _s3ObjectStorageRepository;

        public DeleteObjectHandler(IS3ObjectStorageRepository s3ObjectStorageRepository)
        {
            _s3ObjectStorageRepository = s3ObjectStorageRepository;
        }

        public async Task<int> Handle(DeleteObjectCommand request, CancellationToken cancellationToken)
        {
            var response = await _s3ObjectStorageRepository.GetObject(request.BucketName, request.ObjectName);
            if ((int)response.HttpStatusCode != (int)HttpStatusCode.OK)
                return await Task.FromResult(0);

            return await _s3ObjectStorageRepository.DeleteObject(request.BucketName, request.ObjectName);
        }
    }
}
