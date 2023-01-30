using AWS_Serverless_StorageApplication.Models;
using AWS_Serverless_StorageApplication.Repositories.Interfaces;

namespace AWS_Serverless_StorageApplication.Repositories.Repositories
{
    //https://github.com/awsdocs/aws-doc-sdk-examples/tree/main/dotnetv3/S3
    public class S3ObjectStorageRepository : IS3ObjectStorageRepository
    {
        public Task<ObjectDetails> CreateObject(ObjectDetails fileDetails)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteObject(string guid)
        {
            throw new NotImplementedException();
        }

        public async Task<ObjectDetails> GetObject(string guid)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ObjectDetails>> GetObjectList()
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateObject(ObjectDetails guid)
        {
            throw new NotImplementedException();
        }
    }
}
