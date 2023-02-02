using AWS_Serverless_StorageApplication.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Serverless_StorageApplication.Commands.BucketCommands
{
    public class CreateBucketCommand: IRequest<int>
    {
        public string BucketName { get; set; } = string.Empty;

        public CreateBucketCommand(string bucketName)
        {
            BucketName = bucketName;
        }
    }
}
