using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Serverless_StorageApplication.Controllers.BucketControllers
{
    public class BucketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BucketController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
