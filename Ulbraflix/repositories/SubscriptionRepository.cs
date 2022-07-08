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

    public void Insert(Subscription entity)
    {
        entity.IsActive = true;
        _dataContext.Add(entity);
        _dataContext.SaveChangesAsync();
    }

    public void Update(Subscription entity)
    {
        _dataContext
            .Subscription
            .Update(entity);
        _dataContext.SaveChangesAsync();
    }

    public void Delete(int id)
    {
        Subscription subscription = GetById(id);
        _dataContext.Subscription.Remove(subscription);
        _dataContext.SaveChangesAsync();
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