using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql")
    .AddDatabase("sqldb");

builder.AddProject<Api>("api")
    .WithReference(sql)
    .WaitFor(sql);

builder.Build().Run();
