using System.Net;
using dotNET_Temporal.Config;
using dotNET_Temporal.DTO;
using dotNET_Temporal.Entity;
using dotNET_Temporal.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace dotNET_Temporal.Endpoints;

public class UserEndpoints: IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app, ILogger logger)
    {
        app.MapPost("/",
        [Tags("User")]
        [EndpointDescription("Create a new user.")]
        [ProducesResponseType<User>((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        async (CreateOrUpdateUserDto dto, [FromServices] IUserService service) =>
        {
            try
            {
                await service.Create(dto);

                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });

        app.MapPut("/{id}",
        [Tags("User")]
        [EndpointDescription("Update a created user by id")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        async (int id, CreateOrUpdateUserDto dto, [FromServices] IUserService service) =>
        {
            try
            {
                await service.Update(dto, id);

                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });

        app.MapGet("Changes/{id}",
        [Tags("User")]
        [EndpointDescription("Get all changes including in a temporal table in User by id.")]
        [ProducesResponseType<IQueryable<User>>((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        async (int id, [FromServices] IUserService service) =>
        {
            var changes = service.GetAllUsersWithTemporalById(id);

            if (changes is null || !changes.Any()) return Results.NoContent();

            return Results.Ok(changes);
        });
    }
}
