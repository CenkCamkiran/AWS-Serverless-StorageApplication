using AWS_Serverless_StorageApplication.Commands.BucketCommands;
using AWS_Serverless_StorageApplication.Helpers;
using AWS_Serverless_StorageApplication.Models;
using AWS_Serverless_StorageApplication.Repositories.Interfaces;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace AWS_Serverless_StorageApplication.Handlers.BucketHandlers
{
    public class DeleteBucketHandler : IRequestHandler<DeleteBucketCommand, BucketResponse>
    {

        private readonly IS3ObjectStorageRepository _s3ObjectStorageRepository;

        public DeleteBucketHandler(IS3ObjectStorageRepository s3ObjectStorageRepository)
        {
            _s3ObjectStorageRepository = s3ObjectStorageRepository;
        }

        public async Task<BucketResponse> Handle(DeleteBucketCommand request, CancellationToken cancellationToken)
        {
            int response = await _s3ObjectStorageRepository.DeleteBucketAsync(request.BucketName);

            if (response == (int)HttpStatusCode.OK)
            {
                BucketResponse bucketResponse = new BucketResponse();
                bucketResponse.BucketName = request.BucketName;
                bucketResponse.ResponseCode = response;
                bucketResponse.ResponseDescription = "Bucket deleted successfully!";

                return bucketResponse;
            }
            else
            {
                StorageApplicationError error = new StorageApplicationError();
                error.Message = "Error occurred during bucket deletion!";
                error.ResponseCode = response;

                throw new StorageApplicationException(JsonConvert.SerializeObject(error));
            }
        }
    }
}
