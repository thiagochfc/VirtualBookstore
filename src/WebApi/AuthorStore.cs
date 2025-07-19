using System.Collections.Concurrent;

using Moonad;

using VirtualBookstore.WebApi.Authors;
using VirtualBookstore.WebApi.Commons.Types;

namespace VirtualBookstore.WebApi;

internal class AuthorStore : IAuthorStore
{
    private static readonly ConcurrentBag<Author> _authors = new();

    public Task<Option<Author>> GetByEmailAsync(Email email, CancellationToken cancellationToken)
    {
        var result = _authors.FirstOrDefault(x => x.Email == email).ToOption();
        return Task.FromResult(result);
    }

    public Task CreateAsync(Author author, CancellationToken cancellationToken)
    {
        _authors.Add(author);
        return Task.CompletedTask;
    }
}
