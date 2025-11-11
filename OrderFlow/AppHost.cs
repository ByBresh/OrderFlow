var builder = DistributedApplication.CreateBuilder(args);

// Configure PostgreSQL database
var postgres = builder.AddPostgres("identity")
    .WithLifetime(ContainerLifetime.Persistent);

// Add a database to the PostgreSQL instance
var identitydb = postgres.AddDatabase("indentitydb");

// Add the OrderFlow services
builder.AddProject<Projects.OrderFlow_Identity>("orderflow-identity")
    .WaitFor(postgres)
    .WithReference(identitydb);

builder.Build().Run();
