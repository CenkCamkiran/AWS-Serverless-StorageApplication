using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Serverless_StorageApplication.Helpers
{
    public class StorageApplicationException : Exception
    {
        public StorageApplicationException()
        {
        }

        public StorageApplicationException(string? message) : base(message)
        {
        }
    }
}
