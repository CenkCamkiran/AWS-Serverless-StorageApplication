using Amazon.S3.Model;
using AWS_Serverless_StorageApplication.Commands.BucketCommands;
using AWS_Serverless_StorageApplication.Models;
using AWS_Serverless_StorageApplication.Queries.BucketQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AWS_Serverless_StorageApplication.Controllers
{
    [Route("api/main/[controller]")]
    [ApiController]
    public class BucketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BucketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<S3Bucket>> GetBucketListAsync()
        {
            List<S3Bucket> bucketList = await _mediator.Send(new GetBucketListQuery());

            return bucketList;
        }

        [HttpPut("{bucketname}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //Task<IActionResult>
        public async Task<BucketResponse> CreateBucketAsync(string bucketname)
        {
            var response = await _mediator.Send(new CreateBucketCommand(bucketname));

            return response;
        }

        [HttpDelete("{bucketname}")]
        public async Task<BucketResponse> DeleteBucketAsync(string bucketname)
        {
            var response = await _mediator.Send(new DeleteBucketCommand(bucketname));

            return response;
        }
    }
}
