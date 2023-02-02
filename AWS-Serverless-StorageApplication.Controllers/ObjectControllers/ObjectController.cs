using Amazon.S3.Model;
using AWS_Serverless_StorageApplication.Commands.ObjectCommands;
using AWS_Serverless_StorageApplication.Models;
using AWS_Serverless_StorageApplication.Queries.ObjectQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AWS_Serverless_StorageApplication.Controllers.ObjectControllers
{
    [Route("api/main/[controller]")]
    [ApiController]
    public class ObjectController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ObjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("objectlist/bucketname/{bucketname}")]
        public async Task<List<S3Object>> GetObjectList(string bucketname)
        {
            List<S3Object> objectList = await _mediator.Send(new GetObjectListQuery(bucketname));

            return objectList;
        }

        [HttpGet("bucketname/{bucketname}/object/{objectname}")]
        public async Task<GetObjectResponse> GetObject(string bucketname, string objectname)
        {
            GetObjectResponse objectResponse = await _mediator.Send(new GetObjectQuery(bucketname, objectname));

            return objectResponse;
        }

        //[HttpPut]
        //public async Task<ObjectDetails> CreateObject([FromForm] ObjectDetails objectDetails)
        //{
        //    return null;
        //}

        [HttpDelete("bucketname/{bucketname}/object/{objectname}")]
        public async Task<ObjectResponse> DeleteObject(string bucketname, string objectname)
        {
            int response = await _mediator.Send(new DeleteObjectCommand(bucketname, objectname));

            ObjectResponse objectResponse = new ObjectResponse();
            objectResponse.ObjectName = objectname;
            objectResponse.BucketName = bucketname;
            objectResponse.ResponseCode = response;
            objectResponse.ResponseDescription = "Object deleted successfully!";

            return objectResponse;
        }

    }
}
