using AWS_Serverless_StorageApplication.Models;

namespace AWS_Serverless_StorageApplication.Repositories.Interfaces
{
    public interface IS3ObjectStorageRepository
    {
        Task<ObjectDetails> GetObject(string guid);
        Task<List<ObjectDetails>> GetObjectList();
        Task<string> DeleteObject(string guid);
        Task<string> UpdateObject(ObjectDetails guid);
        Task<int> CreateObject(ObjectDetails fileDetails);

    }
}
