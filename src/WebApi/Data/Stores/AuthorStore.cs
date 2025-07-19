using Microsoft.EntityFrameworkCore;

using Moonad;

using VirtualBookstore.WebApi.Authors;
using VirtualBookstore.WebApi.Commons.Types;

namespace VirtualBookstore.WebApi.Data.Stores;

internal class AuthorStore(AppDbContext context) : IAuthorStore
{
    public async Task<Option<Author>> GetByEmailAsync(Email email, CancellationToken cancellationToken) =>
        await context.Authors.AsNoTracking().SingleOrDefaultAsync(x => x.Email == email, cancellationToken);

    public async Task CreateAsync(Author author, CancellationToken cancellationToken)
    {
        await context.AddAsync(author, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}
