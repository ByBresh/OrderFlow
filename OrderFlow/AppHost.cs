var builder = DistributedApplication.CreateBuilder(args);

// Configure PostgreSQL database
var postgres = builder.AddPostgres("identity")
    .WithLifetime(ContainerLifetime.Persistent);

// Add a database to the PostgreSQL instance
var identitydb = postgres.AddDatabase("identitydb");

// Add the OrderFlow services
var identityApi = builder.AddProject<Projects.OrderFlow_Identity>("orderflow-identity")
    .WaitFor(postgres)
    .WithReference(identitydb);

// Add the React frontend
var frontend = builder.AddNpmApp("orderflow-front", "../orderflow.front")
    .WithReference(identityApi)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
