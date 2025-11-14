var builder = DistributedApplication.CreateBuilder(args);

// ==============================================
// DATABASE CONFIGURATION - PostgreSQL
// ==============================================

// PostgreSQL database
var postgres = builder.AddPostgres("postgres")
    .WithLifetime(ContainerLifetime.Persistent); // Make database persistent

// Identity database
var identityDb = postgres.AddDatabase("identity-db");

// ==============================================
// MICROSERVICES
// ==============================================

// Identity API
var identityApi = builder.AddProject<Projects.OrderFlow_Identity>("orderflow-identity")
    .WithReference(identityDb)
    .WaitFor(identityDb); // Ensure the database is ready before starting the service

// ==============================================
// FRONTEND APPLICATION - React
// ==============================================
var frontend = builder.AddNpmApp("orderflow-front", "../orderflow.front")
    .WithReference(identityApi)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
