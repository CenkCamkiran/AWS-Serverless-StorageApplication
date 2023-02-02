using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Serverless_StorageApplication.Commands.BucketCommands
{
    public class DeleteBucketCommand: IRequest<int>
    {
        public string BucketName { get; set; } = string.Empty;

        public DeleteBucketCommand(string bucketName)
        {
            BucketName = bucketName;
        }
    }
}
