using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ulbraflix.data.context;
using Ulbraflix.domain.entities;
using Ulbraflix.entities;
using Ulbraflix.repositories.interfaces;

namespace Ulbraflix.repositories;

public class SubscriptionRepository : ISubscriptionRepository
{
    private DataContext _dataContext;

    public SubscriptionRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Subscription GetById(int id)
    {
        return _dataContext
            .Subscription
            .Include(subscription => subscription.User)
            .Include(subscription => subscription.UsersProfiles)
            .SingleOrDefault(subscription => subscription.Id == id);
    }

    public List<Subscription> GetAll()
    {
        return _dataContext
            .Subscription
            .Include(subscription => subscription.User)
            .Include(subscription => subscription.UsersProfiles)
            .ToList();
    }

    public bool Insert(Subscription entity)
    {
        entity.IsActive = true;
        _dataContext.Add(entity);
        return (_dataContext.SaveChanges()) > 0;
    }

    public bool Update(Subscription entity)
    {
        _dataContext
            .Subscription
            .Update(entity);
        return (_dataContext.SaveChanges()) > 0;
    }

    public bool Delete(Subscription subscription)
    {
        _dataContext
            .Subscription
            .Remove(subscription);
        return (_dataContext.SaveChanges()) > 0;
    }

    public async Task<Subscription> GetByIdAsync(int id)
    {
        return await _dataContext
            .Subscription
            .Include(subscription => subscription.User)
            .Include(subscription => subscription.UsersProfiles)
            .FirstOrDefaultAsync(subscription => subscription.Id == id);
    }

    public async Task<IList<Subscription>> GetAllAsync()
    {
        return await _dataContext
            .Subscription
            .Include(subscription => subscription.User)
            .Include(subscription => subscription.UsersProfiles)
            .ToListAsync();
    }
}