using AWS_Serverless_StorageApplication.Commands.ObjectCommands;
using AWS_Serverless_StorageApplication.Helpers;
using AWS_Serverless_StorageApplication.Models;
using AWS_Serverless_StorageApplication.Repositories.Interfaces;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace AWS_Serverless_StorageApplication.Handlers.ObjectHandlers
{
    public class CreateObjectHandler : IRequestHandler<CreateObjectCommand, ObjectResponse>
    {

        private readonly IS3ObjectStorageRepository _s3ObjectStorageRepository;

        public CreateObjectHandler(IS3ObjectStorageRepository s3ObjectStorageRepository)
        {
            _s3ObjectStorageRepository = s3ObjectStorageRepository;
        }

        public async Task<ObjectResponse> Handle(CreateObjectCommand request, CancellationToken cancellationToken)
        {
            ObjectDetails objectInfo = new ObjectDetails()
            {
                SizeInBytes = request.ObjectDetails.SizeInBytes,
                ContentType = request.ObjectDetails.ContentType,
                CreateDate = request.ObjectDetails.CreateDate,
                MetaData = request.ObjectDetails.MetaData,
                Name = request.ObjectDetails.Name
            };

            int response = await _s3ObjectStorageRepository.CreateObjectAsync(request.BucketName, objectInfo, request.ObjectStream);

            ObjectResponse objectResponse = new ObjectResponse();
            if (response == (int)HttpStatusCode.OK)
            {
                objectResponse.BucketName = request.BucketName;
                objectResponse.ResponseCode = response;
                objectResponse.ResponseDescription = "Object created successfully!";
                objectResponse.ObjectName = request.ObjectDetails.Name;

                return objectResponse;
            }
            else
            {
                StorageApplicationError error = new StorageApplicationError();
                error.Message = "Error occurred during object creation!";
                error.ResponseCode = response;

                throw new StorageApplicationException(JsonConvert.SerializeObject(error));
            }

        }
    }
}
