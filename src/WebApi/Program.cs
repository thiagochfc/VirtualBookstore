using Microsoft.EntityFrameworkCore;

using VirtualBookstore.WebApi.Authors;
using VirtualBookstore.WebApi.Commons.Extensions;
using VirtualBookstore.WebApi.Data;
using VirtualBookstore.WebApi.Data.Stores;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.AddDocumentation();
builder.AddProblemDetails();
builder.AddValidation();
builder.AddNpgsqlDbContext<AppDbContext>("virtualbookstore");
builder.Services.AddScoped<IAuthorStore, AuthorStore>();

builder.AddServiceDefaults();

WebApplication app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.ConfigureDevelopment();

    await using var scope = app.Services.CreateAsyncScope();
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var strategy = context.Database.CreateExecutionStrategy();
    await strategy.ExecuteAsync(() => context.Database.MigrateAsync());
}

app.UseProblemDetails();
app.UseSecurity();
app.MapEndpoints();

await app.RunAsync();
