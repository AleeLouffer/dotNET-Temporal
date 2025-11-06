using dotNET_Temporal.Config;

var builder = WebApplication.CreateBuilder(args);

builder.AddApiConfiguration();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseApiConfiguration();

app.Run();
