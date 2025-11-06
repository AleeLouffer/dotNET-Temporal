using dotNET_Temporal.Util;
using Microsoft.AspNetCore.HttpOverrides;
using Scalar.AspNetCore;

namespace dotNET_Temporal.Config;

public static class ApiConfig
{
    public static void AddApiConfiguration(this WebApplicationBuilder builder)
    {
        builder.Logging.SetMinimumLevel(LogLevel.Error);
        builder.Services.AddOpenApi();
        builder.Services.ConfigureHttpJsonOptions(x =>
        {
            x.SerializerOptions.WriteIndented = true;
            x.SerializerOptions.IncludeFields = true;
        });

        builder.Services.AddHealthChecks();
        builder.Services.AddLocalization();
        builder.InjectDepedencies();
    }

    public static void UseApiConfiguration(this WebApplication app)
    {
        app.MapEndpoints();

        app.MapOpenApi();

        app.MapScalarApiReference(x => x.AddDocuments([new ScalarDocument("v1", "SQL Temporal Tables")]));
    }
}
