using AWS_Serverless_StorageApplication.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Serverless_StorageApplication.Repositories.Repositories
{
    public class S3ObjectStorageRepository : IS3ObjectStorageRepository
    {
        public Task DeleteObjectByGuid(string guid)
        {
            throw new NotImplementedException();
        }

        public object GetObjectByGuid(string guid)
        {
            throw new NotImplementedException();
        }

        public object GetObjectsList()
        {
            throw new NotImplementedException();
        }

        public Task UpdateObjectByGuid(string guid)
        {
            throw new NotImplementedException();
        }
    }
}
