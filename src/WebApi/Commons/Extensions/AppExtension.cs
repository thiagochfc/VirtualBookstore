using Scalar.AspNetCore;

namespace VirtualBookstore.WebApi.Commons.Extensions;

internal static class AppExtension
{
    internal static void ConfigureDevelopment(this WebApplication app)
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
    }

    internal static void UseSecurity(this WebApplication app)
    {
        app.UseHttpsRedirection();
    }

    internal static void UseProblemDetails(this WebApplication app)
    {
        app.UseExceptionHandler();
        app.UseStatusCodePages();
    }

    internal static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = typeof(Program).Assembly
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IEndpoint)) && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IEndpoint>();

        foreach (var endpoint in endpoints)
        {
            endpoint.MapEndpoint(app);
        }
    }
}
