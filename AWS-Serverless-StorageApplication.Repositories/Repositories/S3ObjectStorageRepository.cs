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

        public async Task<int> CreateObject(string bucketName, ObjectDetails fileDetails, Stream stream)
        {
            stream.Position = 0;

            try
            {
                await _amazonS3Client.EnsureBucketExistsAsync(bucketName);

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

        public async Task<int> DeleteObject(string bucketName, string objectName)
        {
            try
            {
                await _amazonS3Client.EnsureBucketExistsAsync(bucketName);
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

        public async Task<GetObjectResponse> GetObject(string bucketName, string objectName)
        {
            try
            {
                await _amazonS3Client.EnsureBucketExistsAsync(bucketName);
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

        public async Task<List<S3Object>> GetObjectList(string bucketName)
        {
            try
            {
                await _amazonS3Client.EnsureBucketExistsAsync("file_storage");

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

        public async Task<int> DeleteBucket(string bucketName)
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

        public async Task<int> CreateBucket(string bucketName)
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

        public async Task<List<S3Bucket>> ListBuckets()
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
    }
}
