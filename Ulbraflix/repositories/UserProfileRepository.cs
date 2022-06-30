using Ulbraflix.entities;
using Ulbraflix.repositories.interfaces;

namespace Ulbraflix.repositories;

public class UserProfileRepository : IUserProfileRepository
{
    private DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public UserProfile GetById(int id)
    {
        return _dataContext.UserProfile.SingleOrDefault(userProfile => userProfile.id = id);
    }

    public List<UserProfile> GetAll()
    {
        return _dataContext.UserProfile.ToList();
    }

    public void Insert(UserProfile entity)
    {
        _dataContext.UserProfile.Add(entity);
    }

    public void Update(UserProfile entity)
    {
        _dataContext.UserProfile.Update(entity);
    }

    public void Delete(int id)
    {
        UserProfile userProfile = GetById(id);
        _dataContext.UserProfile.Remove(userProfile);
    }
}