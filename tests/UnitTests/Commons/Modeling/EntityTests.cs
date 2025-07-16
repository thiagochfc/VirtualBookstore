using VirtualBookstore.WebApi.Commons.Modeling;

namespace VirtualBookstore.UnitTests.Commons.Modeling;

public class EntityTests
{
    [Fact]
    public void ShouldBeEqualSuccessfully()
    {
        // Arrange
        EntityTest entity1 = new(1);
        EntityTest entity2 = new(1);

        // Assert
        Assert.Equal(entity1, entity2);
    }

    [Fact]
    public void ShouldNotBeEqualDueToIdDifferent()
    {
        // Arrange
        EntityTest entity1 = new(1);
        EntityTest entity2 = new(2);

        // Assert
        Assert.NotEqual(entity1, entity2);
    }

    private sealed class EntityTest(int id) : Entity<int>(id);
}
