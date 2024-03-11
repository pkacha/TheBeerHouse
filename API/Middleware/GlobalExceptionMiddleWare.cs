using API.Errors;
using Microsoft.AspNetCore.Diagnostics;

namespace API.Middleware
{
    // This is a new way to configure error in .net 8
    internal sealed class GlobalExceptionMiddleWare : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionMiddleWare> _logger;
        private readonly IHostEnvironment _environment;

        public GlobalExceptionMiddleWare(ILogger<GlobalExceptionMiddleWare> logger, IHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

            var response = _environment.IsDevelopment()
                   ? new ApiException(httpContext.Response.StatusCode, exception.Message, exception.StackTrace?.ToString())
                   : new ApiException(httpContext.Response.StatusCode, exception.Message, "Internal Server Error");

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

            return true;
        }
    }
}