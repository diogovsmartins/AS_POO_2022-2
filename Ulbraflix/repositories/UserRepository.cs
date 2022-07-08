using Microsoft.EntityFrameworkCore;
using Ulbraflix.data.context;
using Ulbraflix.domain.entities;
using Ulbraflix.repositories.interfaces;

namespace Ulbraflix.repositories;

public class UserRepository : IUserRepository
{
    private DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public User GetById(int id)
    {
        return _dataContext.User.SingleOrDefault(user => user.Id == id);
    }

    public List<User> GetAll()
    {
        return _dataContext.User.ToList();
    }

    public bool Insert(User entity)
    {
        _dataContext.User.Add(entity);
        return (_dataContext.SaveChanges()) > 0;
    }

    public bool Update(User entity)
    {
        _dataContext.User.Update(entity);
        return (_dataContext.SaveChanges()) > 0;
    }
    

    public bool Delete(User user)
    {
        _dataContext.User.Remove(user);
        return (_dataContext.SaveChanges()) > 0;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _dataContext
            .User
            .FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task<IList<User>> GetAllAsync()
    {
        return await _dataContext
            .User
            .ToListAsync();
    }
}