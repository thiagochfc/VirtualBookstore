using System.Diagnostics;
using System.Reflection;

using FluentValidation;

using Microsoft.AspNetCore.Http.Features;

namespace VirtualBookstore.WebApi.Commons.Extensions;

internal static class BuilderExtensions
{
    internal static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApi();
    }

    internal static void AddValidation(this WebApplicationBuilder builder)
    {
        builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
    }

    internal static void AddProblemDetails(this WebApplicationBuilder builder)
    {
        builder.Services.AddProblemDetails(options => options.CustomizeProblemDetails = context =>
        {
            context.ProblemDetails.Instance =
                $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";

            context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);

            Activity? activity = context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;
            context.ProblemDetails.Extensions.TryAdd("traceId", activity?.Id);
        });
        builder.Services.AddExceptionHandler<CustomExceptionHandler>();
    }
}
