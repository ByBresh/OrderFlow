var builder = DistributedApplication.CreateBuilder(args);

// Configure PostgreSQL database
var postgres = builder.AddPostgres("postgres")
    .WithLifetime(ContainerLifetime.Persistent);

// Add a database to the PostgreSQL instance
var postgresdb = postgres.AddDatabase("postgresdb");

// Add the OrderFlow services
builder.AddProject<Projects.OrderFlow_Identity>("orderflow-identity")
    .WaitFor(postgres)
    .WithReference(postgresdb);

builder.Build().Run();
