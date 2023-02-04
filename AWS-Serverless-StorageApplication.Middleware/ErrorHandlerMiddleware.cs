using AWS_Serverless_StorageApplication.Helpers;
using AWS_Serverless_StorageApplication.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mime;

namespace AWS_Serverless_StorageApplication.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (StorageApplicationException exception)
            {
                var response = httpContext.Response;
                response.ContentType = MediaTypeNames.Application.Json;

                StorageApplicationError error = JsonConvert.DeserializeObject<StorageApplicationError>(exception.Message.ToString());
                response.StatusCode = error.ResponseCode;
                response.Headers.Add(HttpResponseHeader.ContentType.ToString(), MediaTypeNames.Application.Json);

                await response.WriteAsync(JsonConvert.SerializeObject(error));
            }
            catch (Exception exception)
            {
                var response = httpContext.Response;
                response.ContentType = MediaTypeNames.Application.Json;

                StorageApplicationError error = new StorageApplicationError();
                error.Message = exception.Message;
                error.ResponseCode = (int)HttpStatusCode.InternalServerError;
                response.StatusCode = error.ResponseCode;
                response.Headers.Add(HttpResponseHeader.ContentType.ToString(), MediaTypeNames.Application.Json);

                await response.WriteAsync(JsonConvert.SerializeObject(error));
            }
        }
    }

    public static class ErrorHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
