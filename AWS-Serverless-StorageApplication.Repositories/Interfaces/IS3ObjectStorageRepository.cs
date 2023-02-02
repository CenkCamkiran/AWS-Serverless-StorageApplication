using Amazon.S3.Model;
using AWS_Serverless_StorageApplication.Models;

namespace AWS_Serverless_StorageApplication.Repositories.Interfaces
{
    public interface IS3ObjectStorageRepository
    {
        Task<GetObjectResponse> GetObject(string bucketName, string objectName);
        Task<List<S3Object>> GetObjectList(string bucketName);
        Task<int> DeleteObject(string bucketName, string objectName);
        Task<int> CreateObject(string bucketName, ObjectDetails fileDetails, Stream stream);
        Task<int> CreateBucket(string bucketName);
        Task<int> DeleteBucket(string bucketName);
        Task<List<S3Bucket>> ListBuckets();
    }
}
