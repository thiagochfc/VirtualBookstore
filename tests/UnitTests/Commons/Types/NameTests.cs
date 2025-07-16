using VirtualBookstore.WebApi.Commons.Types;

using Vogen;

namespace VirtualBookstore.UnitTests.Commons.Types;

public class NameTests
{
    [Fact]
    public void ShouldBeCreatedSuccessfully()
    {
        // Arrange
        Name name = Name.From("Foo");

        // Assert
        Assert.True(name.IsInitialized());
    }

    [Theory]
    [InlineData("")]
    [InlineData("a")]
    public void ShouldNotCreateDueToInvalidName(string input)
    {
        string value = string.IsNullOrEmpty(input)
            ? input
            : new string(input.First(), 101);

        Assert.Throws<ValueObjectValidationException>(() => Name.From(value));
    }
}
