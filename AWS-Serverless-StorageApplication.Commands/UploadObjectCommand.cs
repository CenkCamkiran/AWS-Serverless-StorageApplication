using AWS_Serverless_StorageApplication.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Serverless_StorageApplication.Commands
{
    public class UploadObjectCommand: IRequest<FileDetails>
    {
    }
}
