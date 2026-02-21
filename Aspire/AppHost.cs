using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddSqlServer("sql")
    .WithDataVolume("data")
    .WithLifetime(ContainerLifetime.Persistent)
    .AddDatabase("sqldb");

builder.AddProject<Tester>("tester");

builder.Build().Run();
