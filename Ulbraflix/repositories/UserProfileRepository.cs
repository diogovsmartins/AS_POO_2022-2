using System.Linq;
using Ulbraflix.data.context;
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
        return _dataContext.UserProfile.SingleOrDefault(userProfile => userProfile.Id == id);
    }

    public List<UserProfile> GetAll()
    {
        return _dataContext.UserProfile.ToList();
    }

    public bool Insert(UserProfile entity)
    {
        if (entity.Equals(null) ||
            entity.Name.Equals(String.Empty))
            throw new ArgumentException();
        bool success=true;
        try
        {
            _dataContext.UserProfile.Add(entity);
            _dataContext.SaveChanges();
            return success;
        }
        catch (Exception e )
        {
            success = false;
        }
        return success;
    }

    public bool Update(UserProfile entity)
    {
        if (entity.Equals(null) ||
            entity.Name.Equals(String.Empty))
            throw new ArgumentException();
        bool success=true;
        try
        {
            _dataContext.UserProfile.Update(entity);
            _dataContext.SaveChanges();
            return success;
        }
        catch (Exception e )
        {
            success = false;
        }
        return success;
    }

    public bool Delete(int id)
    {
        bool success=true;
        try
        {
            UserProfile userProfile = GetById(id);
            _dataContext.UserProfile.Remove(userProfile);
            _dataContext.SaveChanges();
            return success;
        }
        catch (Exception e )
        {
            success = false;
        }
        return success;
    }
}