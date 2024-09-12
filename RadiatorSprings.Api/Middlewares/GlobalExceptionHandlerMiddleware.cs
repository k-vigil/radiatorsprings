using System.Net;
using System.Text.Json;
using ValidationException = RadiatorSprings.Application.Common.Exceptions.ValidationException;

namespace RadiatorSprings.Api.Middlewares;

public class GlobalExceptionHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            List<string> errors = new();

            if (ex is ValidationException vex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                errors = vex.Errors;
            }

            var res = new
            {
                HttpStatus = HttpStatusCode.InternalServerError,
                ex.Message,
                Errors = errors.Any() ? errors : [ex.Message]
            };

            var json = JsonSerializer.Serialize(res);

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(json);
        }
    }
}
