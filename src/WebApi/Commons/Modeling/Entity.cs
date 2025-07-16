using System.Diagnostics.CodeAnalysis;

namespace VirtualBookstore.WebApi.Commons.Modeling;

internal abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : IEquatable<TId>
{
    internal TId Id { get; init; }

    protected Entity([NotNull] TId id)
    {
        if (id.Equals(default))
        {
            throw new ArgumentException("Id cannot be default", nameof(id));
        }

        Id = id;
    }

    public bool Equals(Entity<TId>? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (other.GetType() != GetType())
        {
            return false;
        }

        return Id.Equals(other.Id);
    }

    public override bool Equals(object? obj) =>
        Equals(obj as Entity<TId>);

    public override int GetHashCode() =>
        HashCode.Combine(GetType(), Id);

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right) =>
        left?.Equals(right) ?? false;

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right) =>
        !(left == right);
}
