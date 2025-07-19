using System.Reflection;

using Microsoft.EntityFrameworkCore;

using VirtualBookstore.WebApi.Authors;

namespace VirtualBookstore.WebApi.Data;

internal class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
