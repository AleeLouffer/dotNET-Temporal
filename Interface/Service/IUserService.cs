using dotNET_Temporal.DTO;
using dotNET_Temporal.Entity;

namespace dotNET_Temporal.Interface.Service;

public interface IUserService
{
    Task Create(CreateOrUpdateUserDto dto);
    Task Update(CreateOrUpdateUserDto dto, int userId);
    IQueryable<User> GetAllUsersWithTemporalById(int id);
}
