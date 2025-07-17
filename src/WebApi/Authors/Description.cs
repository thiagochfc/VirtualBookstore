using System.Diagnostics.CodeAnalysis;

using Vogen;

namespace VirtualBookstore.WebApi.Authors;

[ValueObject<string>]
[SuppressMessage("Minor Code Smell",
    "S1210:\"Equals\" and the comparison operators should be overridden when implementing \"IComparable\"")]
[SuppressMessage("Design",
    "MA0097:A class that implements IComparable<T> or IComparable should override comparison operators")]
internal readonly partial struct Description
{
    private const short MaxLength = 400;

    private static Validation Validate(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return Validation.Invalid("Description cannot be empty");
        }

        if (input.Length > MaxLength)
        {
            return Validation.Invalid("Description cannot be longer than 400 characters");
        }

        return Validation.Ok;
    }
}
