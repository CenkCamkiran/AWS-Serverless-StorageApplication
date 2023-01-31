using Amazon.S3;
using Amazon.S3.Model;
using AWS_Serverless_StorageApplication.Models;
using AWS_Serverless_StorageApplication.Repositories.Interfaces;

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

        public async Task<int> CreateObject(ObjectDetails fileDetails)
        {
            try
            {
                await _amazonS3Client.EnsureBucketExistsAsync("file_storage");

                PutObjectRequest request = new PutObjectRequest();
                request.

                var response = await _amazonS3Client.PutObjectAsync();
            }
            catch (Exception exception)
            {
                //Logging
            }
            throw new NotImplementedException();
        }

        public async Task<string> DeleteObject(string guid)
        {
            await _amazonS3.EnsureBucketExistsAsync("file_storage");
            throw new NotImplementedException();
        }

        public async Task<ObjectDetails> GetObject(string guid)
        {
            await _amazonS3.EnsureBucketExistsAsync("file_storage");
            throw new NotImplementedException();
        }

        public async Task<List<ObjectDetails>> GetObjectList()
        {
            await _amazonS3.EnsureBucketExistsAsync("file_storage");
            throw new NotImplementedException();
        }

        public async Task<string> UpdateObject(ObjectDetails guid)
        {
            await _amazonS3.EnsureBucketExistsAsync("file_storage");
            throw new NotImplementedException();
        }
    }
}
