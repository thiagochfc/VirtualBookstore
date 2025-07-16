using VirtualBookstore.WebApi.Commons.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.AddDocumentation();
builder.AddProblemDetails();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.ConfigureDevelopment();
}

app.UseProblemDetails();
app.UseSecurity();

await app.RunAsync();
