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

        [HttpGet("bucketlist")]
        public async Task<List<S3Bucket>> GetBucketList()
        {
            List<S3Bucket> bucketList = await _mediator.Send(new GetBucketListQuery());

            return bucketList;
        }

        [HttpPut("{bucketname}")]
        public async Task<BucketResponse> CreateBucket(string bucketname)
        {
            int response = await _mediator.Send(new CreateBucketCommand(bucketname));

            BucketResponse bucketResponse = new BucketResponse();
            bucketResponse.BucketName = bucketname;
            bucketResponse.ResponseCode = response;
            bucketResponse.ResponseDescription = "Bucket created successfully!";

            return bucketResponse;
        }

        [HttpDelete("{bucketname}")]
        public async Task<BucketResponse> DeleteBucket(string bucketname)
        {
            int response = await _mediator.Send(new DeleteBucketCommand(bucketname));

            BucketResponse bucketResponse = new BucketResponse();
            bucketResponse.BucketName = bucketname;
            bucketResponse.ResponseCode = response;
            bucketResponse.ResponseDescription = "Bucket deleted successfully!";

            return bucketResponse;
        }
    }
}
