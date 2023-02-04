using Amazon.S3;
using Amazon.S3.Model;
using AWS_Serverless_StorageApplication.Helpers;
using AWS_Serverless_StorageApplication.Models;
using AWS_Serverless_StorageApplication.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Net;

namespace AWS_Serverless_StorageApplication.Repositories.Repositories
{
    //https://github.com/awsdocs/aws-doc-sdk-examples/tree/main/dotnetv3/S3
    public class S3ObjectStorageRepository : IS3ObjectStorageRepository
    {

        private readonly IAmazonS3 _amazonS3Client;

        public S3ObjectStorageRepository(IAmazonS3 amazonS3Client)
        {
            _amazonS3Client = amazonS3Client;
        }

        public async Task<int> CreateObjectAsync(string bucketName, ObjectDetails fileDetails, Stream stream)
        {
            stream.Position = 0;

            try
            {
                await CheckBucketExistsAsync(bucketName);

                PutObjectRequest request = new PutObjectRequest();
                request.BucketName = bucketName;
                request.ContentType = fileDetails.ContentType;
                request.Key = fileDetails.Name;
                request.InputStream = stream;
                request.Headers.ContentLength = fileDetails.SizeInBytes;
                foreach (var item in fileDetails.MetaData)
                    request.Metadata.Add(item.Key, item.Value);

                var response = await _amazonS3Client.PutObjectAsync(request);

                return (int)response.HttpStatusCode;

            }
            catch (Exception exception)
            {
                StorageApplicationError error = new StorageApplicationError();
                error.Message = exception.Message;
                error.ResponseCode = (int)HttpStatusCode.InternalServerError;

                throw new StorageApplicationException(JsonConvert.SerializeObject(error));
            }
        }

        public async Task<int> DeleteObjectAsync(string bucketName, string objectName)
        {
            try
            {
                await CheckBucketExistsAsync(bucketName);
                var response = await _amazonS3Client.DeleteObjectAsync(bucketName, objectName);

                return (int)response.HttpStatusCode;

            }
            catch (Exception exception)
            {
                StorageApplicationError error = new StorageApplicationError();
                error.Message = exception.Message;
                error.ResponseCode = (int)HttpStatusCode.InternalServerError;

                throw new StorageApplicationException(JsonConvert.SerializeObject(error));
            }
        }

        public async Task<GetObjectResponse> GetObjectAsync(string bucketName, string objectName)
        {
            try
            {
                await CheckBucketExistsAsync(bucketName);
                var response = await _amazonS3Client.GetObjectAsync(bucketName, objectName);

                return response;

            }
            catch (Exception exception)
            {
                StorageApplicationError error = new StorageApplicationError();
                error.Message = exception.Message;
                error.ResponseCode = (int)HttpStatusCode.InternalServerError;

                throw new StorageApplicationException(JsonConvert.SerializeObject(error));
            }
        }

        public async Task<List<S3Object>> GetObjectListAsync(string bucketName)
        {
            try
            {
                await CheckBucketExistsAsync(bucketName);

                ListObjectsV2Request request = new ListObjectsV2Request
                {
                    BucketName = bucketName,
                    MaxKeys = 1000,
                };
                //_amazonS3Client.ListObjectsAsync(bucketName);
                var response = await _amazonS3Client.ListObjectsV2Async(request);

                return response.S3Objects;

            }
            catch (Exception exception)
            {
                StorageApplicationError error = new StorageApplicationError();
                error.Message = exception.Message;
                error.ResponseCode = (int)HttpStatusCode.InternalServerError;

                throw new StorageApplicationException(JsonConvert.SerializeObject(error));
            }
        }

        public async Task<int> DeleteBucketAsync(string bucketName)
        {
            try
            {
                var response = await _amazonS3Client.DeleteBucketAsync(bucketName);

                return (int)response.HttpStatusCode;

            }
            catch (Exception exception)
            {
                StorageApplicationError error = new StorageApplicationError();
                error.Message = exception.Message;
                error.ResponseCode = (int)HttpStatusCode.InternalServerError;

                throw new StorageApplicationException(JsonConvert.SerializeObject(error));
            }
        }

        public async Task<int> CreateBucketAsync(string bucketName)
        {
            try
            {
                var response = await _amazonS3Client.PutBucketAsync(bucketName);

                return (int)response.HttpStatusCode;
            }
            catch (Exception exception)
            {
                StorageApplicationError error = new StorageApplicationError();
                error.Message = exception.Message;
                error.ResponseCode = (int)HttpStatusCode.InternalServerError;

                throw new StorageApplicationException(JsonConvert.SerializeObject(error));
            }
        }

        public async Task<List<S3Bucket>> ListBucketsAsync()
        {
            try
            {
                var response = await _amazonS3Client.ListBucketsAsync();

                return response.Buckets;
            }
            catch (Exception exception)
            {
                StorageApplicationError error = new StorageApplicationError();
                error.Message = exception.Message;
                error.ResponseCode = (int)HttpStatusCode.InternalServerError;

                throw new StorageApplicationException(JsonConvert.SerializeObject(error));
            }
        }

        public async Task CheckBucketExistsAsync(string bucketname)
        {
            PutBucketResponse bucketResponse;
            bool isBucketExists = await _amazonS3Client.DoesS3BucketExistAsync(bucketname);

            if (!isBucketExists)
            {
                bucketResponse = await _amazonS3Client.PutBucketAsync(bucketname);

                if ((int)bucketResponse.HttpStatusCode != (int)HttpStatusCode.OK)
                {
                    StorageApplicationError error = new StorageApplicationError();
                    error.Message = "Error occurred during bucket creation!";
                    error.ResponseCode = (int)bucketResponse.HttpStatusCode;

                    throw new StorageApplicationException(JsonConvert.SerializeObject(error));
                }
            }
        }
    }
}
