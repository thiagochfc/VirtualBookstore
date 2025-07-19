using Microsoft.AspNetCore.Mvc;

namespace VirtualBookstore.WebApi.Commons.Utils;

internal static class Endpoint
{
    internal const string JsonContentType = "application/json";

    internal static ValidationProblemDetails CreateProblemDetails(string key, string message)
    {
        var error = new Dictionary<string, string[]>(1, StringComparer.Ordinal) { { key, [message] } };
        return new ValidationProblemDetails(error);
    }
}
