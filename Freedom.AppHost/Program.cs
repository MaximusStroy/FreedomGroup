var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Freedom_ApiService>("Api");

builder.AddProject<Projects.Freedom_Web>("WebClient")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.AddProject<Projects.Freedom_WebAdmin>("WebAdmin");

builder.Build().Run();
