using AWS_Serverless_StorageApplication.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Serverless_StorageApplication.Commands
{
    public class DeleteObjectCommand: IRequest<string>
    {
        public string Name { get; set; } = string.Empty;

        public DeleteObjectCommand(string name)
        {
            Name = name;
        }
    }
}
