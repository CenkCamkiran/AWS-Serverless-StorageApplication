using AWS_Serverless_StorageApplication.Models;
using MediatR;

namespace AWS_Serverless_StorageApplication.Queries.ObjectQueries
{
    public class GetObjectQuery : IRequest<ObjectDetails>
    {
        public string Guid { get; set; } = string.Empty;
    }
}
