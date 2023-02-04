using AWS_Serverless_StorageApplication.Helpers;
using AWS_Serverless_StorageApplication.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace AWS_Serverless_StorageApplication.Middleware
{
    public class RequestValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            HttpRequest request = httpContext.Request;

            if (!request.HasFormContentType)
            {
                StorageApplicationError error = new StorageApplicationError();
                error.Message = "Content-Type should be multipart/form-data!";
                error.ResponseCode = (int)HttpStatusCode.BadRequest;

                throw new StorageApplicationException(JsonConvert.SerializeObject(error));
            }

            IFormCollection formData = await httpContext.Request.ReadFormAsync();

            if (!formData.Files.Any())
            {
                StorageApplicationError error = new StorageApplicationError();
                error.Message = "Request should contain file data!";
                error.ResponseCode = (int)HttpStatusCode.BadRequest;

                throw new StorageApplicationException(JsonConvert.SerializeObject(error));
            }

            IFormFile file = formData.Files.GetFile("file");

            if (file.Length == 0)
            {
                StorageApplicationError error = new StorageApplicationError();
                error.Message = "File must be exists!";
                error.ResponseCode = (int)HttpStatusCode.BadRequest;

                throw new StorageApplicationException(JsonConvert.SerializeObject(error));
            }

            long fileLength = Convert.ToInt64(Environment.GetEnvironmentVariable("FILE_LENGTH_LIMIT"));
            if (file.Length == fileLength)
            {
                StorageApplicationError error = new StorageApplicationError();
                error.Message = $"File length must be less than {fileLength} byte!";
                error.ResponseCode = (int)HttpStatusCode.BadRequest;

                throw new StorageApplicationException(JsonConvert.SerializeObject(error));
            }

            await _next(httpContext);
        }
    }

    public static class RequestValidationMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestValidationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestValidationMiddleware>();
        }
    }
}
