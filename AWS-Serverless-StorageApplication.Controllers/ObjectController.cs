using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Model;
using AWS_Serverless_StorageApplication.Commands.ObjectCommands;
using AWS_Serverless_StorageApplication.Models;
using AWS_Serverless_StorageApplication.Queries.ObjectQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWS_Serverless_StorageApplication.Controllers
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

        [HttpGet("bucket/{bucketname}/object")]
        public async Task<List<S3Object>> GetObjectListAsync(string bucketname)
        {
            List<S3Object> objectList = await _mediator.Send(new GetObjectListQuery(bucketname));

            return objectList;
        }

        [HttpGet("bucket/{bucketname}/object/{objectname}")]
        public async Task<GetObjectResponse> GetObjectAsync(string bucketname, string objectname)
        {
            GetObjectResponse objectResponse = await _mediator.Send(new GetObjectQuery(bucketname, objectname));

            return objectResponse;
        }

        [HttpPut("bucket/{bucketname}/object")]
        public async Task<ObjectResponse> CreateObjectAsync([FromForm] IFormFile file, string bucketname)
        {
            Dictionary<string, string> metaData = new Dictionary<string, string>();
            metaData.Add("fileName", file.FileName);

            ObjectDetails objectDetails = new ObjectDetails()
            {
                ContentType = file.ContentType,
                CreateDate = DateTime.Now,
                Name = Guid.NewGuid().ToString(),
                SizeInBytes = file.Length,
                MetaData = metaData
            };

            ObjectResponse? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);

                response = await _mediator.Send(new CreateObjectCommand(bucketname, objectDetails, ms));
            }

            return response;

        }

        [HttpDelete("bucket/{bucketname}/object/{objectname}")]
        public async Task<NoContentResult> DeleteObjectAsync(string bucketname, string objectname)
        {
            await _mediator.Send(new DeleteObjectCommand(bucketname, objectname));

            return NoContent();
        }

    }
}
