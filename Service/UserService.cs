using dotNET_Temporal.DTO;
using dotNET_Temporal.Entity;
using dotNET_Temporal.Interface.Repository;
using dotNET_Temporal.Interface.Service;

namespace dotNET_Temporal.Service;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task Create(CreateOrUpdateUserDto dto)
    {
        var user = new User(dto);

        if (!await userRepository.Insert(user))
            throw new Exception("Failed to create a user.");
    }

    public async Task Update(CreateOrUpdateUserDto dto, int userId)
    {
        var user = await userRepository.FindById(userId)
            ?? throw new Exception($"User with id: '{userId}' not found.");

        user.Update(dto);

        if (!await userRepository.Update(user))
            throw new Exception("Failed to update a user.");
    }

    public IQueryable<User> GetAllUsersWithTemporalById(int id) => userRepository.GetAllWithTemporalById(id);
}
