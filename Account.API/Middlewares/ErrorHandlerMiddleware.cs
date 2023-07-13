using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Account.API.Middlewares
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class ErrorHandlerMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ErrorHandlerMiddleware> _logger;

		public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (Exception e)
			{
				_logger.LogError(e, "InternalError");

				httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
				await httpContext.Response.WriteAsJsonAsync(new
				{
					Error = e.Message,
				});
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
