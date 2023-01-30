using AWS_Serverless_StorageApplication.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Serverless_StorageApplication.Queries.ReadQueries
{
    public class GetObjectsListQuery: IRequest<List<FileDetails>>
    {
    }
}
