using Amazon.S3.Model;
using AWS_Serverless_StorageApplication.Models;

namespace AWS_Serverless_StorageApplication.Repositories.Interfaces
{
    public interface IS3ObjectStorageRepository
    {
        Task<GetObjectResponse> GetObjectAsync(string bucketName, string objectName);
        Task<List<S3Object>> GetObjectListAsync(string bucketName);
        Task<int> DeleteObjectAsync(string bucketName, string objectName);
        Task<int> CreateObjectAsync(string bucketName, ObjectDetails fileDetails, Stream stream);
        Task<int> CreateBucketAsync(string bucketName);
        Task<int> DeleteBucketAsync(string bucketName);
        Task<List<S3Bucket>> ListBucketsAsync();
    }
}
