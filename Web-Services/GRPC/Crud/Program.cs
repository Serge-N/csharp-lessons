using Crud.Models;
using Crud.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// Only do this during development. Not using TLS will result in gRPC messages being sent without encryption.
//builder.WebHost.ConfigureKestrel(options =>
//{
//    // Setup a HTTP/2 endpoint without TLS.
//    options.ListenLocalhost(5287, o => o.Protocols =
//        HttpProtocols.Http2);
//});

// Add services to the container.
builder.Services.AddGrpc();
var connectionString = builder.Configuration.GetConnectionString("AppDbContext");
builder.Services.AddDbContext<LearnContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("cors", policy =>
    {
        policy.AllowAnyMethod()
              .AllowAnyHeader()
              .AllowAnyOrigin()
              .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<ProductsAppService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
