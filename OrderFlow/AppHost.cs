var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres");
var postgresdb = postgres.AddDatabase("postgresdb");

builder.AddProject<Projects.OrderFlow_Identity>("orderflow-identity")
    .WithReference(postgresdb);

builder.Build().Run();
