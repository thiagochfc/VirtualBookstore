namespace VirtualBookstore.WebApi.Authors;

using Types = Commons.Types;

public record CreateAuthorRequest(string Name, string Email, string Description)
{
    internal Author ToAuthor() =>
        new(Types.Name.From(Name),
            Types.Email.From(Email),
            Authors.Description.From(Description));
};
