using dotNET_Temporal.Archtecture;
using dotNET_Temporal.Data;
using dotNET_Temporal.Entity;
using dotNET_Temporal.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace dotNET_Temporal.Repository;

public class UserRepository(Context context) : BaseRepository<User, Context>(context), IUserRepository
{
    public async Task<User?> FindById(int id) => await _dbSet.FindAsync(id);

    public IQueryable<User> GetAllWithTemporalById(int id) => _dbSet.TemporalAll().Where(x => x.Id == id);
}
