using AWS_Serverless_StorageApplication.Commands.ObjectCommands;
using AWS_Serverless_StorageApplication.Helpers;
using AWS_Serverless_StorageApplication.Models;
using AWS_Serverless_StorageApplication.Repositories.Interfaces;
using MediatR;
using Newtonsoft.Json;
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
            int response = await _s3ObjectStorageRepository.DeleteObjectAsync(request.BucketName, request.ObjectName);

            ObjectResponse objectResponse = new ObjectResponse();
            if (response == (int)HttpStatusCode.NoContent)
                return response;
            else
            {
                StorageApplicationError error = new StorageApplicationError();
                error.Message = "Error occurred during object deletion!";
                error.ResponseCode = response;

                throw new StorageApplicationException(JsonConvert.SerializeObject(error));
            }

        }
    }
}
