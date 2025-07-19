var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("virtualbookstore")
    .WithPgAdmin(pgAdmin => pgAdmin.WithHostPort(5050))
    .WithHostPort(5432)
    .AddDatabase("virtualbookstore");

builder.AddProject<Projects.VirtualBookstore_WebApi>("webapi")
    .WithReference(postgres)
    .WaitFor(postgres);

await builder.Build().RunAsync();
