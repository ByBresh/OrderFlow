var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.OrderFlow_Identity>("orderflow-identity");

builder.Build().Run();
