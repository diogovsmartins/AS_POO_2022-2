using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ulbraflix.data.context;
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
        return _dataContext.User.SingleOrDefault(user => user.Id == id);
    }

    public List<User> GetAll()
    {
        return _dataContext.User.ToList();
    }

    public void Insert(User entity)
    {
        _dataContext.User.Add(entity);
        _dataContext.SaveChangesAsync();
    }

    public void Update(User entity)
    {
        _dataContext.User.Update(entity);
        _dataContext.SaveChangesAsync();
    }

    public void Delete(int id)
    {
        User user = GetById(id);
        _dataContext.User.Remove(user);
        _dataContext.SaveChangesAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _dataContext
            .User
            .FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task<IList<User>> GetAllByIdAsync()
    {
        return await _dataContext
            .User
            .ToListAsync();
    }
}