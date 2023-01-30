using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Serverless_StorageApplication.Data.Interfaces
{
    public interface IS3ObjectStorageContext
    {
        object GetObject(string Guid);
        List<object> GetObjects();
        Task DeleteObject(string guid);
        Task UpdateFileByGuid(string guid);
    }
}
