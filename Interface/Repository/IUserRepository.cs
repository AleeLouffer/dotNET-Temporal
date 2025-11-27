using dotNET_Temporal.Archtecture;
using dotNET_Temporal.Entity;

namespace dotNET_Temporal.Interface.Repository;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindById(int id);
    IQueryable<User> GetAllWithTemporalById(int id);
}
