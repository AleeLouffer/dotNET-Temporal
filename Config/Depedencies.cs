using dotNET_Temporal.Data;
using Microsoft.EntityFrameworkCore;

namespace dotNET_Temporal.Config;

public static class Depedencies
{
    public static void InjectDepedencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<Context>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("TemporalDB"));
        });

        builder.Services.AddEndpoints(typeof(Program).Assembly);
    }
}
