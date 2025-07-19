using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;

using VirtualBookstore.WebApi.Commons;
using VirtualBookstore.WebApi.Commons.Types;
using VirtualBookstore.WebApi.Commons.Utils;

using Vogen;

using Endpoint = VirtualBookstore.WebApi.Commons.Utils.Endpoint;

namespace VirtualBookstore.WebApi.Authors;

internal class CreateAuthorEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/authors", HandleAsync)
            .WithName("CreateAuthor")
            .WithTags("Authors")
            .WithSummary("Create a new author")
            .WithSummary("Create a new author in the system")
            .Accepts<CreateAuthorRequest>(Endpoint.JsonContentType)
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
            .AddFluentValidationAutoValidation()
            .WithOpenApi();
    }

    private static async Task<IResult> HandleAsync(CreateAuthorRequest request,
        IAuthorStore authorStore,
        CancellationToken cancellationToken)
    {
        var exists = await authorStore.GetByEmailAsync(Email.From(request.Email), cancellationToken);
        if (exists)
        {
            return TypedResults.Conflict(Endpoint.CreateProblemDetails("Email", "Email already exists"));
        }

        await authorStore.CreateAsync(request.ToAuthor(), cancellationToken);

        return TypedResults.Ok();
    }
}
