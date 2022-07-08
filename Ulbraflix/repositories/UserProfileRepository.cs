
using Microsoft.EntityFrameworkCore;
using Ulbraflix.data.context;
using Ulbraflix.domain.entities;
using Ulbraflix.entities;
using Ulbraflix.repositories.interfaces;

namespace Ulbraflix.repositories;

public class UserProfileRepository : IUserProfileRepository
{
    private DataContext _dataContext;

    public UserProfileRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public UserProfile GetById(int id)
    {
        return _dataContext
            .UserProfile
            .Include(userProfile => userProfile.WatchHistory)
            .SingleOrDefault(userProfile => userProfile.Id == id);
    }

    public List<UserProfile> GetAll()
    {
        return _dataContext
            .UserProfile
            .Include(userProfile => userProfile.WatchHistory)
            .ToList();
    }

    public void Insert(UserProfile entity)
    {
        _dataContext
            .UserProfile
            .Add(entity);
        _dataContext.SaveChangesAsync();
    }

    public void Update(UserProfile entity)
    {
        _dataContext.UserProfile.Update(entity);
        _dataContext.SaveChangesAsync();
    }

    public void Delete(int id)
    {
        UserProfile userProfile = GetById(id);
        _dataContext.UserProfile.Remove(userProfile);
        _dataContext.SaveChangesAsync();
    }

    public async Task<UserProfile> GetByIdAsync(int id)
    {
        return await _dataContext
            .UserProfile
            .Include(userProfile => userProfile.WatchHistory)
            .FirstOrDefaultAsync(userProfile => userProfile.Id == id);
    }

    public async Task<IList<UserProfile>> GetAllAsync()
    {
        return await _dataContext
            .UserProfile
            .Include(userProfile => userProfile.WatchHistory)
            .ToListAsync();
    }
}