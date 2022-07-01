using Ulbraflix.entities;
using Ulbraflix.repositories.interfaces;

namespace Ulbraflix.Controllers;

public class UserRepository : IUserRepository
{
    private DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public User GetById(int id)
    {
        return _dataContext.User.SingleOrDefault(user => user.id = id);
    }

    public List<User> GetAll()
    {
        return _dataContext.User.ToList();
    }

    public bool Insert(User entity)
    {
        if (entity.Equals(null) ||
            entity.Email.Equals(String.Empty) ||
            entity.Password.Equals(String.Empty)) 
            throw new ArgumentException();
        bool success=true;
        try
        {
            _dataContext.User.Add(entity);
            _dataContext.SaveChanges();
            return success;
        }
        catch (Exception e )
        {
            success = false;
        }
        return success;
    }

    public bool Update(User entity)
    {
        
        if (entity.Equals(null) ||
            entity.Email.Equals(String.Empty) ||
            entity.Password.Equals(String.Empty)) 
            throw new ArgumentException();
        bool success=true;
        try
        {        
            _dataContext.User.Update(entity);
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
            User user = GetById(id);
            _dataContext.User.Remove(user);
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