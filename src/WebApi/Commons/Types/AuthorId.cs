using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Components.Forms;

using Vogen;

namespace VirtualBookstore.WebApi.Commons.Types;

[ValueObject<Guid>]
[SuppressMessage("Minor Code Smell",
    "S1210:\"Equals\" and the comparison operators should be overridden when implementing \"IComparable\"")]
[SuppressMessage("Design",
    "MA0097:A class that implements IComparable<T> or IComparable should override comparison operators")]
internal readonly partial struct AuthorId
{
    private const short ValidVersion = 7;
    public static readonly AuthorId New = From(Guid.CreateVersion7());

    private static Validation Validate(Guid input) =>
        input.Version == ValidVersion
            ? Validation.Ok
            : Validation.Invalid("Invalid version");
}
