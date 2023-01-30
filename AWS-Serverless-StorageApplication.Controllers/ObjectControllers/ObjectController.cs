using AWS_Serverless_StorageApplication.Commands.ObjectCommands;
using AWS_Serverless_StorageApplication.Models;
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

        [HttpGet]
        public async Task<List<ObjectDetails>> GetObjectList()
        {
            List<ObjectDetails> objectList = await _mediator.Send(new GetObjectListQuery());

            return objectList;
        }

        [HttpGet("Name/{Id}")]
        public async Task<ObjectDetails> GetObject(string Id)
        {
            ObjectDetails objectDetails = await _mediator.Send(new GetObjectQuery() { Guid = Id });

            return objectDetails;
        }

        [HttpPut]
        public async Task<ObjectDetails> CreateObject([FromForm] ObjectDetails objectDetails)
        {
            return null;
        }

        [HttpPost("Name/{Id}")]
        public async Task<ObjectDetails> UpdateObject([FromForm] ObjectDetails objectDetails, string Id)
        {
            return null;
        }

        [HttpDelete("Name/{Id}")]
        public async Task<string> DeleteObject(string Id)
        {
            var result = await _mediator.Send(new DeleteObjectCommand(Id));

            return result;
        }

    }
}
