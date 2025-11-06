using dotNET_Temporal.Entity;
using Microsoft.EntityFrameworkCore;

namespace dotNET_Temporal.Data;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(x =>
        {
            x.HasKey(x => x.Id);
            x.ToTable("User", e => e.IsTemporal(t =>
            {
                t.HasPeriodStart("ValidFrom");
                t.HasPeriodEnd("ValidTo");
                t.UseHistoryTable("User_History");
            }));
        });
    }
}
