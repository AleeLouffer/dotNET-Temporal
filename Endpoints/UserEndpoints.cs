using System.Net;
using dotNET_Temporal.Config;
using dotNET_Temporal.Data;
using dotNET_Temporal.DTO;
using dotNET_Temporal.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotNET_Temporal.Endpoints;

public class UserEndpoints: IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app, ILogger logger)
    {
        app.MapPost("/",
        [Tags("User")]
        [EndpointDescription("Creating a new user.")]
        [ProducesResponseType<User>((int)HttpStatusCode.OK)]
        async (CreateOrUpdateUserDto dto, [FromServices] Context context) =>
        {
            var user = new User(dto);

            await context.Set<User>().AddAsync(user);
            await context.SaveChangesAsync();

            return Results.Ok();
        });

        app.MapPut("/{id}",
        [Tags("User")]
        [EndpointDescription("Updating a created user by id")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        async (int id, CreateOrUpdateUserDto dto, [FromServices] Context context) =>
        {
            var user = await context.Set<User>().FindAsync(id);

            if (user is null) return Results.NoContent();

            user.Update(dto);

            context.Set<User>().Entry(user).State = EntityState.Modified;
            context.Set<User>().Update(user);
            await context.SaveChangesAsync();

            return Results.Ok();
        });

        app.MapGet("Changes/{id}",
        [Tags("User")]
        [EndpointDescription("Get all changes in User by id, using temporal table.")]
        [ProducesResponseType<IQueryable<User>>((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        async (int id, [FromServices] Context context) =>
        {
            var changes = context.Set<User>().TemporalAll().Where(x => x.Id == id);

            if (changes is null || !changes.Any()) return Results.NoContent();

            return Results.Ok(changes);
        });
    }
}
