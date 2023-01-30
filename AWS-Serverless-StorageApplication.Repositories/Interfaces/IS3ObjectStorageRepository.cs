using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Serverless_StorageApplication.Repositories.Interfaces
{
    public interface IS3ObjectStorageRepository
    {
        object GetObjectByGuid(string guid);
        object GetObjectsList();
        Task DeleteObjectByGuid(string guid);
        Task UpdateObjectByGuid(string guid);
        
    }
}
