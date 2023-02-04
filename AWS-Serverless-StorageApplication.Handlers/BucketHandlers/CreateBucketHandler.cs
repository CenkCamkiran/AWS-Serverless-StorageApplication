using AWS_Serverless_StorageApplication.Commands.BucketCommands;
using AWS_Serverless_StorageApplication.Helpers;
using AWS_Serverless_StorageApplication.Models;
using AWS_Serverless_StorageApplication.Repositories.Interfaces;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace AWS_Serverless_StorageApplication.Handlers.BucketHandlers
{
    public class CreateBucketHandler : IRequestHandler<CreateBucketCommand, BucketResponse>
    {

        private readonly IS3ObjectStorageRepository _s3ObjectStorageRepository;

        public CreateBucketHandler(IS3ObjectStorageRepository s3ObjectStorageRepository)
        {
            _s3ObjectStorageRepository = s3ObjectStorageRepository;
        }

        public async Task<BucketResponse> Handle(CreateBucketCommand request, CancellationToken cancellationToken)
        {
            int response = await _s3ObjectStorageRepository.CreateBucketAsync(request.BucketName);

            if (response == (int)HttpStatusCode.OK)
            {
                BucketResponse bucketResponse = new BucketResponse();
                bucketResponse.BucketName = request.BucketName;
                bucketResponse.ResponseCode = response;
                bucketResponse.ResponseDescription = "Bucket created successfully!";

                return bucketResponse;
            }
            else
            {
                StorageApplicationError error = new StorageApplicationError();
                error.Message = "Error occurred during bucket creation!";
                error.ResponseCode = response;

                throw new StorageApplicationException(JsonConvert.SerializeObject(error));
            }

        }
    }
}
