var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var books = new List<Book>
{
    new Book("Book One", "Author A", 2001, 3.7, "Fiction"),
    new Book("Book Two", "Author B", 2002, 4.0, "Non-Fiction"),
    new Book("Book Three", "Author A", 2003, 4.5, "Fantasy")
};

app.MapGet("/", () => "Hello World!");

app.MapGet("/hello/{name}", (string name) => $"Hello {name}");
app.MapGet("/hello/{name}/{age}", (string name, int age) => $"Hello {name}, you're {age} years old");

app.MapGet("/books/search", (string author = "Anonim", int year = 2000, double minRating = 5.0) =>
{
    var result = $"Searching for books: ";
    if (author != null) result += $"author={author} ";
    if (year != null) result += $"year={year} ";
    if (minRating != null) result += $"rating>={minRating}";
    return result;
});

app.MapGet("/books", () => books);

app.MapPost("/books", (Book book) =>
{
    books.Add(book);
    return Results.Ok();
});

app.Run();

public record Book(string Title, string Author, int Year, double Rating, string Genre);