using AWS_Serverless_StorageApplication.Models;
using MediatR;

namespace AWS_Serverless_StorageApplication.Queries.ObjectQueries
{
    public class GetObjectListQuery : IRequest<List<ObjectDetails>>
    {
    }
}
