using VirtualBookstore.WebApi.Authors.Endpoints;
using VirtualBookstore.WebApi.Commons;

namespace VirtualBookstore.WebApi.Extensions;

static class ApplicationExtensions
{
    internal static void ConfigureDevelopmentEnvironment(this WebApplication app) =>
        app.MapOpenApi();

    internal static void UseSecurity(this WebApplication app) =>
        app.UseHttpsRedirection();

    internal static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app
            .MapGroup("");

        // Health Check
        endpoints
            .MapGroup("/health")
            .WithName("Health Check")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "OK" });

        // Authors
        endpoints
            .MapGroup("/authors")
            .WithTags("Authors")
            .MapEndpoint<CreateAuthorEndpoint>();
    }
    
    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
