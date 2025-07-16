using VirtualBookstore.WebApi.Commons.Types;

using Vogen;

namespace VirtualBookstore.UnitTests.Commons.Types;

public class EmailTests
{
    [Theory]
    [InlineData("user@example.com")]
    [InlineData("test.email@domain.org")]
    [InlineData("user+tag@example.com")]
    [InlineData("user_name@example.com")]
    [InlineData("user-name@example.com")]
    [InlineData("contact@company.co.uk")]
    [InlineData("admin@sub.domain.com")]
    [InlineData("a@b.co")]
    public void ShouldBeCreatedSuccessfully(string input)
    {
        // Arrange
        Email email = Email.From(input);

        // Assert
        Assert.True(email.IsInitialized());
    }

    [Theory]
    [InlineData("invalid")]
    [InlineData("invalid@")]
    [InlineData("@invalid.com")]
    [InlineData("user@@example.com")]
    [InlineData("user @example.com")]
    [InlineData("user..name@example.com")]
    [InlineData("user@example..com")]
    [InlineData(".user@example.com")]
    [InlineData("user.@example.com")]
    [InlineData("user@example.com.")]
    [InlineData("user@example")]
    [InlineData("user@.com")]
    [InlineData("user name@example.com")]
    public void ShouldNotCreateDueToInvalidEmail(string input)
    {
        // Assert
        Assert.Throws<ValueObjectValidationException>(() => Email.From(input));
    }

    [Fact]
    public void ShouldNotCreateDueToLongEmail()
    {
        // Arrange
        string input = $"user@example.co{new string('m', 241)}";

        // Assert
        Assert.Throws<ValueObjectValidationException>(() => Email.From(input));
    }

    [Fact]
    public void ShouldCreateToLowerSuccessfully()
    {
        // Arrange
        Email email = Email.From("USER@EXAMPLE.COM");

        // Assert
        Assert.True(email.IsInitialized());
        Assert.Equal("user@example.com", email.Value);
    }
}
