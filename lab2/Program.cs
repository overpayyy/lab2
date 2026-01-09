var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/hello/{name}", (string name) => $"Hello {name}");

app.MapGet("/hello/{name}/{age}", (string name, int age) => $"Hello {name}, you're {age} years old");

app.Run();