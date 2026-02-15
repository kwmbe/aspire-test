using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Tester>("tester");

builder.Build().Run();