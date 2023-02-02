using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Serverless_StorageApplication.Models
{
    public class StorageApplicationError
    {
        public int ResponseCode { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
