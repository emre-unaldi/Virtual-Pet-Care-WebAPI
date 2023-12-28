using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace VirtualPetCareWebAPI.Core.Exceptions
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                string message = $"[Request]  HTTP {context.Request.Method} - {context.Request.Path}";

                await _next(context);
                watch.Stop();

                message = $"[Response] HTTP {context.Request.Method}" +
                    $" - {context.Request.Path} responded" +
                    $" {context.Response.StatusCode} in" +
                    $" {watch.Elapsed.TotalMilliseconds} ms";

                _logger.LogInformation(message);
            }
            catch (Exception exception)
            {
                watch.Stop();
                await HandleException(context, exception, watch);
            }
        }

        private Task HandleException(HttpContext context, Exception exception, Stopwatch watch)
        {
            string message = $"[Error]  HTTP {context.Request.Method}" +
                $" - {context.Response.StatusCode}" +
                $"  Error Message {exception.Message}" +
                $" in {watch.Elapsed.TotalMilliseconds} ms";

            _logger.LogError(message);

            var errorDetails = new ErrorDetails
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Errors = exception.Message,
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var json = JsonSerializer.Serialize(errorDetails);

            return context.Response.WriteAsync(json);
        }
    }

    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }

    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Errors { get; set; }
    }
}

