using Moonad;

using VirtualBookstore.WebApi.Commons.Types;

namespace VirtualBookstore.WebApi.Authors;

internal interface IAuthorStore
{
    Task<Option<Author>> GetByEmailAsync(Email email, CancellationToken cancellationToken);
    Task CreateAsync(Author author, CancellationToken cancellationToken);
}
