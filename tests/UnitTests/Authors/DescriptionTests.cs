using VirtualBookstore.WebApi.Authors;

using Vogen;

namespace VirtualBookstore.UnitTests.Authors;

public class DescriptionTests
{
    [Fact]
    public void ShouldBeCreatedSuccessfully()
    {
        // Arrange
        Description description = Description.From("I'm a author");

        // Assert
        Assert.True(description.IsInitialized());
    }

    [Theory]
    [InlineData("")]
    [InlineData("a")]
    public void ShouldNotCreateDueToInvalidDescription(string input)
    {
        // Arrange
        string value = string.IsNullOrEmpty(input)
            ? input
            : new string(input.First(), 401);

        // Assert
        Assert.Throws<ValueObjectValidationException>(() => Description.From(value));
    }
}
