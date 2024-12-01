using Moonad;

namespace VirtualBookstore.WebApi.Books;

public class Book
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Resume { get; private set; }
    public string Summary { get; private set; }
    public decimal Price { get; private set; }
    public uint NumberOfPages { get; private set; }
    public string Isbn { get; private set; }
    public DateOnly Release { get; private set; }
    public Guid IdCategory { get; private set; }
    public Guid IdAuthor { get; private set; }
    public static ushort ResumeMaxLength => 500;
    public static decimal MinimumPriceRequired => 20.00m;
    public static sbyte MinimumNumberOfPages => 100;

    private Book(Guid id,
        string title,
        string resume,
        string summary,
        decimal price,
        uint numberOfPages,
        string isbn,
        DateOnly release,
        Guid idCategory,
        Guid idAuthor) =>
        (Id, Title, Resume, Summary, Price, NumberOfPages, Isbn, Release, IdCategory, IdAuthor) =
        (id, title, resume, summary, price, numberOfPages, isbn, release, idCategory, idAuthor);
    
    public static Result<Book, IBookError> Create(string title,
        string resume,
        string summary,
        decimal price,
        uint numberOfPages,
        string isbn,
        DateOnly release,
        Guid idCategory,
        Guid idAuthor)
    {
        if (string.IsNullOrEmpty(title))
        {
            return BookErrors.TitleNotProvidedError;
        }

        if (string.IsNullOrEmpty(resume))
        {
            return BookErrors.ResumeNotProvidedError;
        }

        if (resume.Length > ResumeMaxLength)
        {
            return BookErrors.ResumeTooLongError;
        }

        if (price < MinimumPriceRequired)
        {
            return BookErrors.PriceInvalidError;
        }

        if (numberOfPages < MinimumNumberOfPages)
        {
            return BookErrors.NumberOfPagesInvalidError;
        }

        if (string.IsNullOrEmpty(isbn))
        {
            return BookErrors.IsbnNotProvidedError;
        }

        if (release <= DateOnly.FromDateTime(DateTime.Now))
        {
            return BookErrors.ReleaseInvalidError;
        }

        if (idCategory.Equals(Guid.Empty))
        {
            return BookErrors.IdCategoryNotProvidedError;
        }

        if (idAuthor.Equals(Guid.Empty))
        {
            return BookErrors.IdAuthorNotProvidedError;
        }
        
        Book book = new (Guid.CreateVersion7(),
            title,
            resume,
            summary,
            price,
            numberOfPages,
            isbn,
            release,
            idCategory,
            idAuthor);
        return book;
    }
    
}
