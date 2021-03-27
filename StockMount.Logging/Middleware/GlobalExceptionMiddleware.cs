using Microsoft.AspNetCore.Http;
using Microsoft.IO;
using Newtonsoft.Json;
using Serilog;
using Application.Dto.ExceptionExtensions;
using Application.Dto.Response;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Application.Logging.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;
        public GlobalExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await HandleRequestAsync(httpContext);
                await HandleResponseAsync(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            ResponseInfo<object> result = new ResponseInfo<object>
            {
                Exception = ex,
                ErrorMessage = ex.InnerExceptionMessage()
            };

            var responseBody = JsonConvert.SerializeObject(result);

            Log.Error(exception: ex, messageTemplate: responseBody);

            await context.Response.WriteAsync(responseBody);
        }

        private async Task HandleRequestAsync(HttpContext context)
        {
            using (var requestStream = _recyclableMemoryStreamManager.GetStream())
            {
                await context.Request.Body.CopyToAsync(requestStream);

                Log.Information(ReadStreamInChunks(requestStream));

                context.Request.Body.Position = 0;
            }
        }
        private static string ReadStreamInChunks(Stream stream)
        {
            const int readChunkBufferLength = 4096;
            stream.Seek(0, SeekOrigin.Begin);
            using var textWriter = new StringWriter();
            using var reader = new StreamReader(stream);
            var readChunk = new char[readChunkBufferLength];
            int readChunkLength;

            do
            {
                readChunkLength = reader.ReadBlock(readChunk, 0, readChunkBufferLength);
                textWriter.Write(readChunk, 0, readChunkLength);
            }

            while (readChunkLength > 0);

            return textWriter.ToString();
        }

        private async Task HandleResponseAsync(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;

            using (var responseBody = _recyclableMemoryStreamManager.GetStream())
            {
                context.Response.Body = responseBody;

                await _requestDelegate(context);
                context.Response.Body.Seek(0, SeekOrigin.Begin);

                var text = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);

                Log.Information(text);

                await responseBody.CopyToAsync(originalBodyStream);
            }
        }
    }
}
