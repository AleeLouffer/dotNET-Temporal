using dotNET_Temporal.Data;
using dotNET_Temporal.Interface.Repository;
using dotNET_Temporal.Interface.Service;
using dotNET_Temporal.Repository;
using dotNET_Temporal.Service;
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

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        
        builder.Services.AddScoped<IUserService, UserService>();

        builder.Services.AddEndpoints(typeof(Program).Assembly);
    }
}
