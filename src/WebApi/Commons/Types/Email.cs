using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

using Vogen;

namespace VirtualBookstore.WebApi.Commons.Types;

[ValueObject<string>]
[SuppressMessage("Design",
    "MA0097:A class that implements IComparable<T> or IComparable should override comparison operators")]
[SuppressMessage("Minor Code Smell",
    "S1210:\"Equals\" and the comparison operators should be overridden when implementing \"IComparable\"")]
internal readonly partial struct Email
{
    private const short MaxLength = 255;

    // Regex generated with AI
    [GeneratedRegex(
        @"^[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase,
        matchTimeoutMilliseconds: 1000)]
    private static partial Regex EmailRegex();

    private static Validation Validate(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return Validation.Invalid("Email cannot be empty");
        }

        if (input.Length > MaxLength)
        {
            return Validation.Invalid("Email cannot be longer than 255 characters");
        }

        return EmailRegex().IsMatch(input)
            ? Validation.Ok
            : Validation.Invalid("Invalid email");
    }

    [SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase")]
    private static string NormalizeInput(string input) =>
        input.Trim().ToLowerInvariant();
}
