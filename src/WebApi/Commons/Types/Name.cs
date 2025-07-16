using System.Diagnostics.CodeAnalysis;

using Vogen;

namespace VirtualBookstore.WebApi.Commons.Types;

[ValueObject<string>]
[SuppressMessage("Minor Code Smell",
    "S1210:\"Equals\" and the comparison operators should be overridden when implementing \"IComparable\"")]
[SuppressMessage("Design",
    "MA0097:A class that implements IComparable<T> or IComparable should override comparison operators")]
internal readonly partial struct Name
{
    private const short MaxLength = 100;

    private static Validation Validate(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return Validation.Invalid("Name cannot be empty");
        }

        if (input.Length > MaxLength)
        {
            return Validation.Invalid("Name cannot be longer than 100 characters");
        }

        return Validation.Ok;
    }
}
