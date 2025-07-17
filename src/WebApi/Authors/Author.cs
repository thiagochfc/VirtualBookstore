using VirtualBookstore.WebApi.Commons.Modeling;
using VirtualBookstore.WebApi.Commons.Types;

namespace VirtualBookstore.WebApi.Authors;

internal class Author : Entity<AuthorId>
{
    internal Name Name { get; }
    internal Email Email { get; }
    internal Description Description { get; }
    internal DateTime CreatedAt { get; }

    private Author(AuthorId id,
        Name name,
        Email email,
        Description description,
        DateTime createdAt) : base(id) =>
        (Name, Email, Description, CreatedAt) = (name, email, description, createdAt);

    internal Author(Name name,
        Email email,
        Description description) :
        this(AuthorId.New, name, email, description, DateTime.UtcNow)
    {
    }
}
